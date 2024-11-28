using UnityEngine;
using static Events;

public class CollectController : MonoBehaviour
{
    private void Start()
    {
        EventManager<OnWheelSpinEnd>.SubscribeToEvent(OnSpinEnd);
    }

    private void OnDestroy()
    {
        EventManager<OnWheelSpinEnd>.UnsubscribeToEvent(OnSpinEnd);
    }

    private void OnSpinEnd(object sender, OnWheelSpinEnd @event)
    {
        Collect();
    }

    private void Collect()
    {
        //...
        GameManager.Instance.IncreaseLevel();
    }
}
