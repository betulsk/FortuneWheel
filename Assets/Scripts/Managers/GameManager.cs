using System;

public class GameManager : Singleton<GameManager>
{
    private int _level = 1;

    public int CurrentLevel
    {
        get { return _level; }
        set { _level = value; }
    }

    public Action OnLevelChanged;

    public void IncreaseLevel()
    {
        CurrentLevel++;
        OnLevelChanged?.Invoke();
    }
}
