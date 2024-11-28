using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;
using static Events;

public class WheelSpinController : MonoBehaviour
{
    private bool _canSpin = true;
    private bool _isSpinning;
    private float _pieceAngle;

    [SerializeField] private Button _spinButton;
    [SerializeField] private Wheel _wheel;

    [SerializeField] private float _speed;
    [SerializeField] private float _rotationRepeat = 2;

    public Action OnSpinStartEvent;
    public Action<WheelItem> OnSpinEndEvent;

    private void Start()
    {
        _spinButton.onClick.AddListener(OnSpinButtonClicked);
        _pieceAngle = 360 / _wheel.WheelItems.Count;
    }

    private void OnDestroy()
    {
        _spinButton.onClick.RemoveListener(OnSpinButtonClicked);
    }

    private void OnSpinButtonClicked()
    {
        if(!TrySpinWheel())
        {
            return;
        }
        Spin();
    }

    private bool TrySpinWheel()
    {
        if(_isSpinning)
        {
            _canSpin = false;
            return _canSpin;
        }
        _canSpin = true;
        return _canSpin;
    }

    private void Spin()
    {
        _canSpin = false;
        _spinButton.interactable = false;
        if(!_isSpinning)
        {
            _isSpinning = true;
            OnSpinStartEvent?.Invoke();

            int index = _wheel.GetRandomItemIndex();
            WheelItem wheelItem = _wheel.WheelItems[index];
            Debug.Log("Item is : " + wheelItem.name);

            float angle = _pieceAngle * index;
            Vector3 targetRotation = Vector3.forward * (360 * _rotationRepeat + angle);

            _wheel.WheelVisualTransform
                .DORotate(targetRotation, _speed, RotateMode.FastBeyond360)
                .SetEase(Ease.OutCubic)
                .OnComplete(() =>
                {
                    _isSpinning = false;
                    _canSpin = true;
                    _spinButton.interactable = true;

                    OnSpinEndEvent?.Invoke(wheelItem);
                    OnWheelSpinEnd onWheelSpinEnd = new OnWheelSpinEnd();
                    onWheelSpinEnd.WheelRewardData = wheelItem.RewardData;
                    EventManager<OnWheelSpinEnd>.CustomAction(this, onWheelSpinEnd);
                });
        }
    }
}
