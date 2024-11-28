using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RewardItem : MonoBehaviour
{
    private int _rewardAmount;

    [SerializeField] private Image _iconImage;
    [SerializeField] private TMP_Text _rewardItemAmountText;
    [SerializeField] private RectTransform _rectTranform;

    public Vector2 RewardItemSizeDelta;

    public void SetVisual(WheelRewardData data)
    {
        RewardItemSizeDelta = _rectTranform.sizeDelta;
        _iconImage.sprite = data.RewardSprite;
        _iconImage.SetNativeSize();
        _rewardAmount = data.RewardMultiplier;
        UpdateAmount();
    }

    public void IncreaseAmount(int amount)
    {
        _rewardAmount += amount;
        UpdateAmount();
    }

    private void UpdateAmount()
    {
        _rewardItemAmountText.SetText(_rewardAmount.ToString());
        UIUtilities.BoingEffect(_rewardItemAmountText.transform, Vector3.one, 1.15f, 0.25f);
    }
}
