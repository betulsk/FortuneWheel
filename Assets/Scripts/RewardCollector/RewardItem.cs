using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RewardItem : MonoBehaviour
{
    [SerializeField] private Image _iconImage;
    [SerializeField] private TMP_Text _rewardItemAmountText;
    [SerializeField] private RectTransform _rectTranform;
    public Vector2 RewardItemSizeDelta;

    public void SetVisual(WheelRewardData data)
    {
        RewardItemSizeDelta = _rectTranform.sizeDelta;
        _iconImage.sprite = data.RewardSprite;
        _iconImage.SetNativeSize();
        _rewardItemAmountText.SetText(data.RewardMultiplier.ToString());
    }
}
