using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelItemController : MonoBehaviour
{
    [SerializeField] private List<WheelRewardData> _wheelRewardDatas;
    [SerializeField] private List<WheelItem> _wheelItems;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        WheelSO wheelSO = GameConfigManager.Instance.GetCurrentWheelSO();
        _wheelRewardDatas = new List<WheelRewardData>();
        _wheelRewardDatas.AddRange(wheelSO.Wheels);
        _wheelRewardDatas.Shuffle();
        _wheelRewardDatas.RemoveRange(_wheelItems.Count - 1, _wheelRewardDatas.Count - _wheelItems.Count);
        for(int i = 0; i < _wheelItems.Count; i++)
        {
            _wheelItems[i].SetItemVisual(_wheelRewardDatas[i]);

        }
    }
}
