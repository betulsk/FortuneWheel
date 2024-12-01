using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgressItemMovementController : MonoBehaviour
{
    private Vector3 _itemParentInitialPosition;
    private float _slideLength;

    [SerializeField] private LevelProgressItemSpawner _itemSpawner;
    [SerializeField] private Transform _itemParentTransform;
    [SerializeField] private HorizontalLayoutGroup _horizontalLayoutGroup;

    private void Start()
    {
        _itemParentInitialPosition = _itemParentTransform.localPosition;
        _slideLength = GetSlideLength();
        GameManager.Instance.OnLevelChanged += OnLevelChanged;
    }

    private void OnDestroy()
    {
        if(GameManager.Instance != null)
        {
            GameManager.Instance.OnLevelChanged -= OnLevelChanged;
        }
    }

    private float GetSlideLength()
    {
        float scrollBarItemWidth = _itemSpawner.ItemPrefab.GetComponent<RectTransform>().rect.width;
        float scrollBarItemSpacing = _horizontalLayoutGroup.spacing;
        return scrollBarItemWidth + scrollBarItemSpacing;
    }

    private void OnLevelChanged()
    {
        float xPos = _itemParentTransform.localPosition.x;
        _itemParentTransform.DOLocalMoveX(xPos - _slideLength, .1f)
            .OnComplete(
            () =>
            {
                MoveLevelBarItem();
                ResetItemParentPosition();
            });
    }

    private void MoveLevelBarItem()
    {
        LevelProgressItem levelBarItem = _itemSpawner.ItemsQueue.Dequeue();
        levelBarItem.transform.SetAsLastSibling();
        _itemSpawner.ItemsQueue.Enqueue(levelBarItem);
        _itemSpawner.LastLevel++;
        levelBarItem.SetDatas(_itemSpawner.LastLevel);
    }

    private void ResetItemParentPosition()
    {
        _itemParentTransform.localPosition = _itemParentInitialPosition;
    }
}
