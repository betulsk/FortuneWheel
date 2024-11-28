using UnityEngine;
using static Events;

public class GameFinishUIWidget : MonoBehaviour
{
    [SerializeField] private Transform _winUITransform;
    [SerializeField] private Transform _bombUITransform;

    private void Start()
    {
        EventManager<OnGameFinished>.SubscribeToEvent(OnGameFinish);
    }

    private void OnGameFinish(object sender, OnGameFinished onGameFinished)
    {
        if(onGameFinished.IsBombExplode)
        {
            _bombUITransform.gameObject.SetActive(true);
            return;
        }
        _winUITransform.gameObject.SetActive(true);
    }
}
