using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WheelVisualController : MonoBehaviour
{
    [SerializeField] private Image _wheelImage;
    [SerializeField] private Image _indicatorImage;

    private void Start()
    {
        GameManager.Instance.OnLevelChanged += OnLevelChanged;
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnLevelChanged -= OnLevelChanged;
    }

    private void OnLevelChanged()
    {
        ChangeVisual(GameManager.Instance.CurrentWheelSO);
    }

    private void ChangeVisual(WheelSO wheelData)
    {
        _wheelImage.sprite = wheelData.WheelSprite;
        _indicatorImage.sprite = wheelData.IndicatorSprite;
    }
}
