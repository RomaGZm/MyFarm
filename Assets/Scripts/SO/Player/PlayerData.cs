
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerData", menuName = "SO/PlayerData", order = 1)]
public class PlayerData : ScriptableObject
{
    [System.Serializable]
    public class DetectionZoneParam
    {
        // Ground, Seed, Watering, Harvest, Wither
        public float groundRadius;
        public float seedRadius;
        public float wateringRadius;
        public float harvestRadius;
        public float witherRadius;


    }

    public DetectionZoneParam detectionZoneParam;

}
