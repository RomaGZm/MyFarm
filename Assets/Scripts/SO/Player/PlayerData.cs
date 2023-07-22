
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerData", menuName = "SO/PlayerData", order = 1)]
public class PlayerData : ScriptableObject
{
    [System.Serializable]
    public class InputParam
    {
        public KeyCode keyAction = KeyCode.E;
        public KeyCode keyEndDay = KeyCode.Space;
        public KeyCode keyWalkForward = KeyCode.W;
        public KeyCode keyWalkBack = KeyCode.S;
        public KeyCode keyWalkLeft = KeyCode.A;
        public KeyCode keyWalkRight = KeyCode.D;

    }
    [System.Serializable]
    public class StaminaParam
    {
        public float staminaMin;
        public float staminaMax;
        public float walkEnergyRecovery_min;
        public float walkEnergyLoss_min;
    }
    [System.Serializable]
    public class SkillsParam
    {
        [Header("Level")]
        [Range(1, 5)]
        public int level;
        public float buidPlantsBoostPerLevel;
        public float plantGrowthBoostPerlevel;
        public float actionZoneSizePerlevel;

        [Header("Actions")]
        public int actionPoints;
        public int actionNexLevel;
        
        
    }
  
    public InputParam inputParam;
    public StaminaParam staminaParam;
    public SkillsParam skillsParam;


}
