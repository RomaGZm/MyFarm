
using UnityEngine;

namespace Core.Player.Tools
{
   
    public abstract class ToolParameters: ScriptableObject
    {
        public ToolsController.ToolType toolType;
        [Range(1,3)]
        public int level = 1;
        public float radius;
        public int price;
        public int staminaPoints;
        public int actionPoints;
        public Color toolColor;
        

    }

     
}

