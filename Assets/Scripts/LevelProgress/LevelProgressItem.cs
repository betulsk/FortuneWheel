using TMPro;
using UnityEngine;

public class LevelProgressItem : MonoBehaviour
{
    private int _level;
    [SerializeField] private TMP_Text _levelText;

    public void SetDatas(int level)
    {
        _level = level;
        _levelText.SetText(level.ToString());
        SetTextColor();
    }

    public void SetEmptyText()
    {
        _levelText.text = string.Empty;
    }

    private void SetTextColor()
    {
        _levelText.color = GameConfigManager.Instance.GetCurrentWheelData(_level).Color;
    }
}
