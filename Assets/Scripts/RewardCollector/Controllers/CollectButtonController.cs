using UnityEngine;
using UnityEngine.UI;
using static Events;

public class CollectButtonController : MonoBehaviour
{
    [SerializeField] private Button _collectButton;

    private void Start()
    {
        _collectButton.onClick.AddListener(OnButtonClicked);
        EventManager<OnWheelSpinStart>.SubscribeToEvent(OnSpinStarted);
        EventManager<OnWheelSpinEnd>.SubscribeToEvent(OnWheelSpinFinished);
    }

    private void OnDestroy()
    {
        _collectButton.onClick.RemoveListener(OnButtonClicked);
        EventManager<OnWheelSpinStart>.UnsubscribeToEvent(OnSpinStarted);
        EventManager<OnWheelSpinEnd>.UnsubscribeToEvent(OnWheelSpinFinished);
    }

    private void OnWheelSpinFinished(object sender, OnWheelSpinEnd @event)
    {
        _collectButton.interactable = true;
    }

    private void OnSpinStarted(object sender, OnWheelSpinStart @event)
    {
        _collectButton.interactable = false;
    }

    private void OnButtonClicked()
    {
        OnGameFinished onGameFinish = new OnGameFinished();
        onGameFinish.IsBombExplode = false;
        EventManager<OnGameFinished>.CustomAction(this, onGameFinish);
    }
}
