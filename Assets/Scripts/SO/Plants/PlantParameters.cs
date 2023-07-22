using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Plants
{
    public abstract class PlantParameters : ScriptableObject
    {
        public Plant.PlantType plantType;
        public int price;
        [Header("Build")]
        public int buildTime;
        public int growthTime;
        [Header("Watering")]
        public int maxAmountWater = 100;

        [Header("Random")]
        public int harvestRndMax;
    
        [Header("Sprites")]
        public Sprite spritePlant;
        public Sprite spriteRemains;


    }
}

