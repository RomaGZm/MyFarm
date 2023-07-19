
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

    public InputParam inputParam;
    public StaminaParam staminaParam;

   
}
