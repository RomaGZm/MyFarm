using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Player.Tools
{

    [CreateAssetMenu(fileName = "ToolSeed", menuName = "SO/ToolSeed", order = 1)]
    [System.Serializable]
    public class ToolSeed : ToolParameters
    {
        public float distance;

    }

}
