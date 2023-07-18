
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerData", menuName = "SO/PlayerData", order = 1)]
public class PlayerData : ScriptableObject
{
    [System.Serializable]
    public class InputParam
    {
        public KeyCode keyAction = KeyCode.E;
        public KeyCode keyEndDay = KeyCode.Space;

    }
    [System.Serializable]
    public class StaminaParam
    {
        public float staminaMin;
        public float staminaMax;
        public float walkDec;
        public float walkInc;
    }

    public InputParam inputParam;
    public StaminaParam staminaParam;


}
