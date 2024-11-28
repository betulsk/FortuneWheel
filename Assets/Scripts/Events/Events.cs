using UnityEngine;

public class Events : MonoBehaviour
{
    public struct OnWheelSpinEnd
    {
        public WheelRewardData WheelRewardData;
    }
    
    public struct OnWheelSpinStart
    {
    }

    public struct OnGameFinished
    {
        public bool IsBombExplode;
    }
}
