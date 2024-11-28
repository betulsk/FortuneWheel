using System;
using System.Collections.Generic;
using UnityEngine;
using static Events;

public class RewardItemUIController : MonoBehaviour
{
    private WheelRewardData _rewardData;
    private Dictionary<ERewardType, RewardItem> _collectedRewardTypesToRewardedItem;

    [SerializeField] private RewardItem _rewardItemPrefab;
    [SerializeField] private RectTransform _rewardItemContentTransform;

    private void Start()
    {
        _collectedRewardTypesToRewardedItem = new Dictionary<ERewardType, RewardItem>();
        EventManager<OnWheelSpinEnd>.SubscribeToEvent(OnSpinEnd);
    }

    private void OnDestroy()
    {
        EventManager<OnWheelSpinEnd>.UnsubscribeToEvent(OnSpinEnd);
    }

    private void OnSpinEnd(object sender, OnWheelSpinEnd onWheelSpinEnd)
    {
        _rewardData = onWheelSpinEnd.WheelRewardData;
        Collect();
    }

    private void Collect()
    {
        if(TrySpawnItem())
        {
            SpawnItem();
        }
        else
        {
            _collectedRewardTypesToRewardedItem[_rewardData.RewardType].IncreaseAmount(_rewardData.RewardMultiplier);
        }
        GameManager.Instance.IncreaseLevel();
    }

    private bool TrySpawnItem()
    {
        if(_collectedRewardTypesToRewardedItem.Count <= 0 || !_collectedRewardTypesToRewardedItem.ContainsKey(_rewardData.RewardType))
        {
            return true;
        }
        return false;
    }

    private void SpawnItem()
    {
        RewardItem rewardItem = Instantiate(_rewardItemPrefab, _rewardItemContentTransform);
        rewardItem.SetVisual(_rewardData);
        Vector2 sizeDelta = _rewardItemContentTransform.sizeDelta;
        sizeDelta.y += rewardItem.RewardItemSizeDelta.y;
        _rewardItemContentTransform.sizeDelta = sizeDelta;
        _collectedRewardTypesToRewardedItem.Add(_rewardData.RewardType, rewardItem);
    }
}
