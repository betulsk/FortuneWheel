using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Events;

public class CollectButtonController : MonoBehaviour
{
    private Tween _scaleTween;
    [SerializeField] private RewardItemUIController _rewardItemController;
    [SerializeField] private Button _collectButton;
    [SerializeField] private SingleReward _singleRewardPrefab;
    [SerializeField] private Transform _spawnTransform;
    [SerializeField] private Transform _targetTransform;
    [SerializeField] private List<SingleReward> _singleRewards;

    private void Start()
    {
        _collectButton.onClick.AddListener(OnButtonClicked);
        EventManager<OnWheelSpinStart>.SubscribeToEvent(OnSpinStarted);
        EventManager<OnWheelSpinEnd>.SubscribeToEvent(OnWheelSpinFinished);
    }

    private void OnDestroy()
    {
        _collectButton.onClick.RemoveListener(OnButtonClicked);
        EventManager<OnWheelSpinStart>.UnsubscribeToEvent(OnSpinStarted);
        EventManager<OnWheelSpinEnd>.UnsubscribeToEvent(OnWheelSpinFinished);
        _scaleTween.Kill();
    }

    private void OnWheelSpinFinished(object sender, OnWheelSpinEnd onWheelSpinEndEvent)
    {
        _collectButton.interactable = true;
    }

    private void OnSpinStarted(object sender, OnWheelSpinStart @event)
    {
        _collectButton.interactable = false;
    }

    private void OnButtonClicked()
    {
        OnGameFinished onGameFinish = new OnGameFinished();
        onGameFinish.IsBombExplode = false;
        EventManager<OnGameFinished>.CustomAction(this, onGameFinish);
    }

    public void SpawnRewardVisualEffect(WheelRewardData wheelData, Vector3 endPosition, Action callBack = null)
    {
        Vector2 spawnPos = _spawnTransform.position;
        Vector2 targetPosition;
        for(int i = 0; i < _singleRewards.Count; i++)
        {
            targetPosition = spawnPos + UnityEngine.Random.insideUnitCircle * 20;
            _singleRewards[i].transform.position = targetPosition;
            _singleRewards[i].SetVisual(wheelData.RewardSprite);
            _singleRewards[i].transform.localScale = Vector3.one;
            _scaleTween = _singleRewards[i].transform.DOScale(Vector3.zero, 1.2f).SetEase(Ease.InBack).SetLink(_singleRewards[i].gameObject);
            _singleRewards[i].transform.DOMove(endPosition, 1.2f)
                .SetEase(Ease.InCubic)
                .SetLink(_spawnTransform.gameObject);
        }
        StartCoroutine(this.WaitForSeconds(1.1f, () =>
        {
            callBack?.Invoke();
        }));
    }
}
