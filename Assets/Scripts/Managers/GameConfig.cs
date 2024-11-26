using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Create a Scriptable Object/GameConfig", fileName = "GameConfig")]
public class GameConfig : ScriptableObject
{
    [SerializeField] private SerializableDictionary<EWheelType, int> _wheelTypeToWheelData;
    [SerializeField] private SerializableDictionary<int, WheelData> _levelCoefToWheelData;
    [SerializeField] public SerializableDictionary<int, WheelData> LevelCoefToWheelData =>_levelCoefToWheelData;
}

[Serializable]
public struct WheelData
{
    public EWheelType WheelType;
    public WheelSO WheelSO;
    public int WheelThresholdLevel;
}