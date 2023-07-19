using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Plants
{
    public abstract class PlantParameters : ScriptableObject
    {
        public Plant.PlantType plantType;
        public int price;
        [Header("Sprites")]
        public Sprite spritePlant;

    }
}

