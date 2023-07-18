using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 namespace Core.Player.Tools
{

    [CreateAssetMenu(fileName = "ToolHarvest", menuName = "SO/ToolHarvest", order = 1)]
    [System.Serializable]
    public class ToolHarvest : ToolParameters
    {
        public float distance;

    }

}
