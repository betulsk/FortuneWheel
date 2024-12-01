using System;
using System.Linq;
using UnityEngine;

public class GameConfigManager : Singleton<GameConfigManager>
{
    [SerializeField] private GameConfig _gameConfig;
    public GameConfig GameConfig => _gameConfig;

    public WheelData GetCurrentWheelData(int currentLevel)
    {
        int lowestLevel = Int32.MinValue;
        foreach(int baseLevel in GameConfig.LevelCoefToWheelData.Dictionary.Keys)
        {
            if(baseLevel <= currentLevel)
            {
                if(lowestLevel < baseLevel)
                {
                    lowestLevel = baseLevel;
                    var keys = GameConfig.LevelCoefToWheelData.Dictionary.Keys.ToList();
                    for(int i = GameConfig.LevelCoefToWheelData.Dictionary.Keys.Count - 1; i < GameConfig.LevelCoefToWheelData.Dictionary.Keys.Count; i--)
                    {
                        if(currentLevel % keys[i] == 0)
                        {
                            lowestLevel = keys[i];
                            return GameConfig.LevelCoefToWheelData.Dictionary[lowestLevel];
                        }
                        else
                        {
                            lowestLevel = 1;
                        }
                    }
                }
            }
        }
        return GameConfig.LevelCoefToWheelData.Dictionary[lowestLevel];
    }

    public WheelSO GetCurrentWheelSO()
    {
        return GetCurrentWheelData(GameManager.Instance.CurrentLevel).WheelSO;
    }

    public EWheelType GetCurrentWheelType()
    {
        return GetCurrentWheelData(GameManager.Instance.CurrentLevel).WheelType;
    }
}
