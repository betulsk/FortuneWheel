using TMPro;
using UnityEngine;

public class LevelProgressItem : MonoBehaviour
{
    [SerializeField] private TMP_Text _levelText;

    public void SetDatas(int level)
    {
        _levelText.SetText(level.ToString());
        SetTextColor();
    }

    public void SetEmptyText()
    {
        _levelText.text = string.Empty;
    }

    private void SetTextColor()
    {
        _levelText.color = GameConfigManager.Instance.GetCurrentWheelData(GameManager.Instance.CurrentLevel).Color;
    }
}
