using UnityEngine;
using UnityEngine.UI;

public class SingleReward : MonoBehaviour
{
    [SerializeField] private Image _rewardImage;
    
    public void SetVisual(Sprite rewardIcon)
    {
        _rewardImage.sprite = rewardIcon;
        _rewardImage.SetNativeSize();
    }
}
