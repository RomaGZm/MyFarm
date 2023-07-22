using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Plants;

[CreateAssetMenu(fileName = "PlantsData", menuName = "SO/PlantsData", order = 1)]
public class PlantsData : ScriptableObject
{

    public List<PlantParameters> plantParameters;

    [Header("Plants")]
    public Sprite spritePlanåNoWater;
    public Sprite spriteHarvest;
    public Sprite spriteRemains;
    public PlantParameters GetPlantWithType(Plant.PlantType plantType)
    {
        foreach (PlantParameters tp in plantParameters)
        {
            if (tp.plantType == plantType)
                return tp;
        }
        return null;
    }

    [System.Serializable]
    public class PlantSkills
    {

        public int daysPlantFruit;
        public int numberFruits;
        public int randomNumberFruits;

    }
}
