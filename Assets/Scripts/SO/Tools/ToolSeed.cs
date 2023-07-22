using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Plants;
namespace Core.Player.Tools
{

    [CreateAssetMenu(fileName = "ToolSeed", menuName = "SO/ToolSeed", order = 1)]
    [System.Serializable]
    public class ToolSeed : ToolParameters
    {
        [Header("Sprites")]
        public Sprite corn;
        public Sprite melon;
        public Sprite strawberry;


        public Sprite GetSpriteWithType(Plant.PlantType plantType)
        {
            switch (plantType)
            {
                case Plant.PlantType.Corn:
                    return corn;
                case Plant.PlantType.Melon:
                    return melon;
                case Plant.PlantType.Strawberry:
                    return strawberry;
            }
            return corn;
        }
    }

}
