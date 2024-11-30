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
        WheelSO wheelSO = GameManager.Instance.CurrentWheelSO;
        var wheelItems = _wheel.WheelItems;
        _wheelRewardDatas = new List<WheelRewardData>();
        _wheelRewardDatas.AddRange(wheelSO.Wheels);
        _wheelRewardDatas.Shuffle();
        _wheelRewardDatas.RemoveRange(wheelItems.Count - wheelSO.RequiredData.Count, _wheelRewardDatas.Count - wheelItems.Count + wheelSO.RequiredData.Count);
        _wheelRewardDatas.AddRange(wheelSO.RequiredData);
        _wheelRewardDatas.Shuffle();
        for(int i = 0; i < wheelItems.Count; i++)
        {
            wheelItems[i].SetItemVisual(_wheelRewardDatas[i]);
        }
    }
}
