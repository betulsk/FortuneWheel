using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WheelItem : MonoBehaviour
{
    [SerializeField] private Image _itemIconImage;
    [SerializeField] private TMP_Text _itemText;

    public WheelRewardData RewardData;

    public void SetItemVisual(WheelRewardData rewardData)
    {
        RewardData = rewardData;
        _itemIconImage.sprite = rewardData.RewardSprite;
        _itemIconImage.SetNativeSize();
        _itemText.SetText(rewardData.RewardMultiplier.ToString());
    }
}
