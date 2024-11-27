using System;
using UnityEngine;

public class GameConfigManager : Singleton<GameConfigManager>
{
    [SerializeField] private GameConfig _gameConfig;
    public GameConfig GameConfig => _gameConfig;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    public WheelData GetCurrentWheelType(int currentLevel)
    {
        int lowestLevel = Int32.MinValue;
        foreach(int baseLevel in GameConfig.LevelCoefToWheelData.Dictionary.Keys)
        {
            if(baseLevel <= currentLevel)
            {
                if(lowestLevel < baseLevel)
                {
                    lowestLevel = baseLevel;
                }
            }
        }
        return GameConfig.LevelCoefToWheelData.Dictionary[lowestLevel];
    }

    public WheelSO GetCurrentWheelSO()
    {
        return GetCurrentWheelType(GameManager.Instance.CurrentLevel).WheelSO;
    }
    
    public EWheelType GetCurrentWheelType()
    {
        return GetCurrentWheelType(GameManager.Instance.CurrentLevel).WheelType;
    }
}
