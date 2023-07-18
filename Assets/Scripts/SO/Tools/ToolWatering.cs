using System.Collections;
using System.Collections.Generic;
using UnityEngine;


 namespace Core.Player.Tools
{

    [CreateAssetMenu(fileName = "ToolWatering", menuName = "SO/ToolWatering", order = 1)]
    [System.Serializable]
    public class ToolWatering : ToolParameters
    {
        public float distance;

    }

}