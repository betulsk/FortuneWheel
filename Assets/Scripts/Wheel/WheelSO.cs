using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create a Scriptable Object/Wheel", fileName = "BaseWheel")]

public class WheelSO : ScriptableObject
{
    [SerializeField] private List<WheelRewardData> _wheels;
    public List<WheelRewardData> Wheels => _wheels;
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
