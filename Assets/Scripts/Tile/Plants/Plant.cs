using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Interfaces;
using UnityEngine.UI;

namespace Core.Plants
{
    public class Plant : MonoBehaviour, Initialize
    {
        [Header("Components")]
        [SerializeField]
        private SpriteRenderer spritePlant;
        [SerializeField]
        private SpriteRenderer spriteState;
        [SerializeField]
        private PlantProgressBar progressBuild;
        [SerializeField]
        private PlantProgressBar progressWatering;
        private PlantsData data;
        private PlantParameters plantParameters;

        private int amountWater_ = 0;
       // [Header("Watering")]
        public int amountWater
        {
            get { return amountWater_; }
            set 
            {
                if (value < plantParameters.maxAmountWater)
                {
                    amountWater_ = value;
                    progressWatering.SetValue(amountWater_);
                }
              
               
               
            }
        }
        

        public enum PlantType
        {
            Corn, Melon, Strawberry
        }
        public enum PlantState
        {
            None, Build, Watering, Growth, Harvest, Remains
        }
        private PlantState _plantState = PlantState.Build;
        public PlantState plantState
        {
            get { return _plantState; }
            set 
            { 
                _plantState = value;
                switch (_plantState)
                {
                    case PlantState.Build:
                        spriteState.gameObject.SetActive(false);
                        break;
                    case PlantState.Watering:
                       
                       // StartCoroutine(WateringPlant());
                        break;
                    case PlantState.Growth:

                        break;
                    case PlantState.Harvest:

                        break;
                    case PlantState.Remains:
                        spriteState.sprite = GameManager.instance.tilesController.plantsData.spriteRemains;
                        spritePlant.sprite = GameManager.instance.tilesController.plantsData.GetPlantWithType(currentPlantType).spriteRemains;
                        break;
                }
            }
        }

        public void Remains()
        {
            EnableSpriteState(false, PlantState.Remains);
        }
        private PlantType _currentPlantType = PlantType.Corn;
        public PlantType currentPlantType 
        {
            get { return _currentPlantType; }
            set 
            { 
                _currentPlantType = value;
                PlantsData data = GameManager.instance.tilesController.plantsData;
                spritePlant.sprite = data.GetPlantWithType(_currentPlantType).spritePlant;
                
                 switch (_currentPlantType)
                {
                    case PlantType.Corn:
                        break;
                    case PlantType.Melon:
                        break;
                    case PlantType.Strawberry:
                        break;
                }
            }
        }
        public void Init()
        {
           
             data = GameManager.instance.tilesController.plantsData;
             plantParameters = data.GetPlantWithType(currentPlantType);
           
            progressWatering.SetMaxValue(plantParameters.maxAmountWater);
        }
        public void Enable(bool en)
        {
            plantState = PlantState.Build;
            gameObject.SetActive(true);

            PlayerData pd = GameManager.instance.playerController.playerData;
            StartCoroutine(BuildPlant(plantParameters.buildTime, pd.skillsParam.buidPlantsBoostPerLevel * pd.skillsParam.level));
        
        }
        public void EnableSpriteState(bool en, PlantState plantState)
        {
            if(plantState == PlantState.Watering)
            {
                spriteState.sprite = GameManager.instance.tilesController.plantsData.spritePlanåNoWater;
            }
            if (plantState == PlantState.Harvest)
            {
                spriteState.sprite = GameManager.instance.tilesController.plantsData.spriteHarvest;
            }
            spriteState.gameObject.SetActive(en);
        }

       
        private IEnumerator BuildPlant(float max, float boost)
        {
            progressBuild.SetMaxValue(max);
            progressBuild.SetValue(0);
            progressBuild.SetFillColor(Color.green);
            progressBuild.gameObject.SetActive(true);
            for (int i = 0; i < max+1; i++)
            {
                yield return new WaitForSeconds(1-boost);
                progressBuild.SetValue(i);
            }
            plantState = PlantState.Growth;
           
            progressBuild.gameObject.SetActive(false);

            EnableSpriteState(true, PlantState.Watering);
            StartCoroutine(WateringPlant());

            
             PlayerData pd = GameManager.instance.playerController.playerData;
             StartCoroutine(GrowthPlant(plantParameters.growthTime, pd.skillsParam.plantGrowthBoostPerlevel));
            // StartCoroutine(WateringPlant(pp.maxAmountWater, 0));

        }
        private IEnumerator WateringPlant()
        {
        
            progressWatering.SetMaxValue(plantParameters.maxAmountWater);
            progressWatering.SetValue(0);
            progressWatering.SetFillColor(Color.blue);
            progressWatering.gameObject.SetActive(true);

            while (true)
            {
                yield return new WaitForSeconds(0.1f);

                if (plantState == PlantState.Growth)
                {
                    if (amountWater > 0)
                    {
                        amountWater--;
                        progressWatering.SetValue(amountWater);
                        EnableSpriteState(false, PlantState.Watering);
                    }
                    else
                    {

                        EnableSpriteState(true, PlantState.Watering);
                    }
                }
                else break;
               

            }
                  
           

        }
        
        private IEnumerator GrowthPlant(float max, float boost)
        {
            progressBuild.SetMaxValue(max);
            progressBuild.SetValue(0);
            progressBuild.SetFillColor(Color.gray);
            progressBuild.gameObject.SetActive(true);

            int growtPoints = 0;

            while (true)
            {
              //  print(1 - boost);
                yield return new WaitForSeconds(1 - boost);
                if (plantState == PlantState.Growth && amountWater > 0)
                {
                  
                    growtPoints++;
                    progressBuild.SetValue(growtPoints);
                 
                    if(growtPoints >= max)
                    {
                        //progressBuild.SetValue(growtPoints);
                      
                        break;
                    }
                        
                       
                }
            }
            EnableSpriteState(true, PlantState.Harvest);
            plantState = PlantState.Harvest;
            progressBuild.gameObject.SetActive(false);
            progressWatering.gameObject.SetActive(false);


        }

       
     
    }
}

