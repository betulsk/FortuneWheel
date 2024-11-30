using System;

public class GameManager : Singleton<GameManager>
{
    private int _level = 1;
    public WheelSO CurrentWheelSO;
    public int CurrentLevel
    {
        get { return _level; }
        set { _level = value; }
    }

    public Action OnLevelChanged;

    private void Awake()
    {
        SetCurrentWheelSO();
    }

    public void IncreaseLevel()
    {
        CurrentLevel++;
        SetCurrentWheelSO();
        OnLevelChanged?.Invoke();
    }

    private void SetCurrentWheelSO()
    {
        CurrentWheelSO = GameConfigManager.Instance.GetCurrentWheelSO();
    }
}
