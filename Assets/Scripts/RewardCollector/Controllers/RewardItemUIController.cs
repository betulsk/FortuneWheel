using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Events;

public class RewardItemUIController : MonoBehaviour
{
    private RewardItem _spawnedRewardItem;
    private WheelRewardData _rewardData;
    private Dictionary<ERewardType, RewardItem> _collectedRewardTypesToRewardedItem;

    [SerializeField] private RewardItem _rewardItemPrefab;
    [SerializeField] private RectTransform _rewardItemContentTransform;
    [SerializeField] private CollectButtonController _collectButtonController;

    public Dictionary<ERewardType, RewardItem> CollectedRewardTypesToRewardedItem => _collectedRewardTypesToRewardedItem;

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
        if(_rewardData.RewardType == ERewardType.Bomb)
        {
            OnGameFinished onGameFinish = new OnGameFinished();
            onGameFinish.IsBombExplode = true;
            EventManager<OnGameFinished>.CustomAction(this, onGameFinish);
            return;
        }

        if(TrySpawnItem())
        {
            SpawnItem();
            _collectButtonController.SpawnRewardVisualEffect(_rewardData, _collectedRewardTypesToRewardedItem.Values.ToList()[^1].transform.position, () =>
            {
                _spawnedRewardItem.UpdateAmount();
            });
        }
        else
        {
            _collectButtonController.SpawnRewardVisualEffect(_rewardData, _collectedRewardTypesToRewardedItem[_rewardData.RewardType].transform.position, () =>
            {
                _collectedRewardTypesToRewardedItem[_rewardData.RewardType].IncreaseAmount(_rewardData.RewardMultiplier);
            });
        }
        GameManager.Instance.IncreaseLevel();
    }

    private bool TrySpawnItem()
    {
        if(_collectedRewardTypesToRewardedItem.Count <= 0
            || !_collectedRewardTypesToRewardedItem.ContainsKey(_rewardData.RewardType)
            && _rewardData.RewardType != ERewardType.Bomb)
        {
            return true;
        }
        return false;
    }

    private void SpawnItem()
    {
        RewardItem rewardItem = Instantiate(_rewardItemPrefab, _rewardItemContentTransform);
        rewardItem.SetVisual(_rewardData);
        _spawnedRewardItem = rewardItem;
        Vector2 sizeDelta = _rewardItemContentTransform.sizeDelta;
        sizeDelta.y += rewardItem.RewardItemSizeDelta.y;
        _rewardItemContentTransform.sizeDelta = sizeDelta;
        _collectedRewardTypesToRewardedItem.Add(_rewardData.RewardType, rewardItem);
    }
}
