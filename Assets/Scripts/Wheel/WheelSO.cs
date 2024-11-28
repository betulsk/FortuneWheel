using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create a Scriptable Object/Wheel", fileName = "BaseWheel")]

public class WheelSO : ScriptableObject
{
    [SerializeField] private List<WheelRewardData> _wheels;
    [SerializeField] private List<WheelRewardData> _requiredData;

    public List<WheelRewardData> Wheels => _wheels;
    public List<WheelRewardData> RequiredData => _requiredData;
}

[Serializable]
public struct WheelRewardData
{
    [SerializeField] private ERewardType _rewardType;
    [SerializeField] private Sprite _rewardSprite;
    [SerializeField] private int _rewardMultiplier;

    public ERewardType RewardType => _rewardType;
    public Sprite RewardSprite => _rewardSprite;
    public int RewardMultiplier => _rewardMultiplier;
}
