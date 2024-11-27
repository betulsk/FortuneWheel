using System.Collections.Generic;
using UnityEngine;

public class WheelItemController : MonoBehaviour
{
    [SerializeField] private Wheel _wheel;
    [SerializeField] private List<WheelRewardData> _wheelRewardDatas;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        WheelSO wheelSO = GameConfigManager.Instance.GetCurrentWheelSO();
        var wheelItems = _wheel.WheelItems;
        _wheelRewardDatas = new List<WheelRewardData>();
        _wheelRewardDatas.AddRange(wheelSO.Wheels);
        _wheelRewardDatas.Shuffle();
        _wheelRewardDatas.RemoveRange(wheelItems.Count - 1, _wheelRewardDatas.Count - wheelItems.Count);
        for(int i = 0; i < wheelItems.Count; i++)
        {
            wheelItems[i].SetItemVisual(_wheelRewardDatas[i]);
        }
    }
}
