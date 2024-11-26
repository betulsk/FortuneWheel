using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelItemController : MonoBehaviour
{
    private List<WheelReward> _wheelRewards;
    [SerializeField] private List<WheelItem> _wheelItems;

    private void Start()
    {
        Init();    
    }

    private void Init()
    {
        WheelSO wheelSO = GameConfigManager.Instance.GetCurrentWheelSO();
        _wheelRewards = new List<WheelReward>();
        for(int i = 0; i < _wheelItems.Count; i++)
        {
            _wheelRewards.Add(wheelSO.Wheels[i]);
        }
        _wheelRewards.Shuffle();
    }
}
