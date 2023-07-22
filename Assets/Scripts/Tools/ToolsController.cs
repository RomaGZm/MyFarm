using System.Collections.Generic;
using UnityEngine;
using Core.Interfaces;
using Core.Tiles;
using Core.UI;
using Core.Plants;

namespace Core.Player.Tools{

    [RequireComponent(typeof(PlayerController))]
    public class ToolsController : MonoBehaviour, Initialize
    {
        [Header("Datas")]
        [SerializeField]
        private ToolsData toolsData;
        [SerializeField]
        private PlantsData plantsData;
        
        [Header("Tool")]
        [HideInInspector]
        public ToolParameters currentTool;

        #region private var
        private PlayerController player;
        private PlantParameters currentPlant;
        private float tempTime = 0;
        private List<Tile> tilesWataring;
        #endregion

        public enum ToolType
        {
            Ground, Seed, Watering, Harvest, Wither
        }

        private void Update()
        {
            if (Input.GetKey(player.playerData.inputParam.keyAction))
            {
                if(currentTool.toolType == ToolType.Watering)
                {
                    tempTime += Time.deltaTime;

                    if (tempTime >= 1)
                    {
                        tilesWataring = GameManager.instance.tilesController.GetTiles(transform.position, currentTool.radius);
                        foreach(Tile tile in tilesWataring)
                        {
                            if(tile.plant.gameObject.activeSelf && tile.plant.plantState == Plant.PlantState.Growth)
                            {
                               
                                tile.plant.amountWater++;
                            }
                           
                        }
                    }
                }
               

            }
        }
        public void Init()
        {
            player = gameObject.GetComponent<PlayerController>();
            currentTool = toolsData.GetTollWithType(ToolType.Ground);
            UIManager.instance.toolsUI.SetSelected(ToolType.Ground);
            player.detectionZone.SetRadius(currentTool.radius);
            player.detectionZone.SetColor(currentTool.toolColor);

            UIManager.instance.toolsUI.UpdateToolsPrice(toolsData.GetTollWithType(ToolType.Ground).price, toolsData.GetTollWithType(ToolType.Seed).price,
                toolsData.GetTollWithType(ToolType.Watering).price, toolsData.GetTollWithType(ToolType.Harvest).price, toolsData.GetTollWithType(ToolType.Wither).price);

            currentPlant = plantsData.GetPlantWithType(Plant.PlantType.Corn);
            UIManager.instance.toolsUI.SetSelected(Plant.PlantType.Corn);
            UIManager.instance.toolsUI.UpdateSeedPrice(plantsData.GetPlantWithType(Plant.PlantType.Corn).price, plantsData.GetPlantWithType(Plant.PlantType.Melon).price, 
                plantsData.GetPlantWithType(Plant.PlantType.Strawberry).price);
            toolsData.GetTollWithType(ToolType.Seed).price = currentPlant.price;
        }

        public void ToolAction()
        {
            List<Tile> tiles;
            ResourcesData resourcesData = GameManager.instance.resourcesController.GetResourcesData();
            switch (currentTool.toolType)
            {
                
                case ToolType.Ground:
                    tiles = GameManager.instance.tilesController.GetTiles(transform.position, currentTool.radius);
                
                    foreach (Tile tile in tiles)
                    {
                     
                        if (tile.tileType == Tile.TileType.Sand)
                        {
                            
                            if(resourcesData.money - currentTool.price >= 0)
                            {
                                GameManager.instance.resourcesController.SubMoney(currentTool.price);
                                tile.tileType = Tile.TileType.Ground;
                                player.playerAction.AddAction(toolsData.GetTollWithType(currentTool.toolType).actionPoints);
                                player.playerStamina.SubStamina(toolsData.GetTollWithType(currentTool.toolType).actionPoints);
                                return;
                            }
                           
                        }
                        
                    }
                    break;
                case ToolType.Seed:
                    tiles = GameManager.instance.tilesController.GetTiles(transform.position, currentTool.radius);
                  
                    foreach (Tile tile in tiles)
                    {
                       
                        if (tile.tileType == Tile.TileType.Ground && !tile.plant.gameObject.activeSelf)
                        {

                            if (resourcesData.money - currentTool.price >= 0)
                            {
                                
                                GameManager.instance.resourcesController.SubMoney(currentTool.price);
                              
                                tile.plant.currentPlantType = currentPlant.plantType;
                                tile.plant.Enable(true);
                                player.playerAction.AddAction(toolsData.GetTollWithType(currentTool.toolType).actionPoints);
                                player.playerStamina.SubStamina(toolsData.GetTollWithType(currentTool.toolType).actionPoints);
                                return;
                            }

                        }

                    }
                    break;
                case ToolType.Watering:
                    tiles = GameManager.instance.tilesController.GetTiles(transform.position, currentTool.radius);

                    foreach (Tile tile in tiles)
                    {

                        if (tile.tileType == Tile.TileType.Sand)
                        {

                            if (resourcesData.money - currentTool.price >= 0)
                            {

                                GameManager.instance.resourcesController.SubMoney(currentTool.price);

                                //tile.plant.currentPlantType = currentPlant.plantType;
                                //tile.plant.plantState = Plant.PlantState.Watering;

                                player.playerAction.AddAction(toolsData.GetTollWithType(currentTool.toolType).actionPoints);
                                player.playerStamina.SubStamina(toolsData.GetTollWithType(currentTool.toolType).actionPoints);
                                return;
                            }

                        }

                    }
                    break;
                case ToolType.Harvest:
                    tiles = GameManager.instance.tilesController.GetTiles(transform.position, currentTool.radius);

                    foreach (Tile tile in tiles)
                    {

                        if (tile.plant.plantState == Plant.PlantState.Harvest)
                        {

                            if (resourcesData.money - currentTool.price >= 0)
                            {
                                PlantParameters pp = plantsData.GetPlantWithType(tile.plant.currentPlantType);
                                GameManager.instance.resourcesController.AddPlantsResource(Random.Range(1, pp.harvestRndMax), tile.plant.currentPlantType);

                                tile.plant.plantState = Plant.PlantState.Remains;

                                player.playerAction.AddAction(toolsData.GetTollWithType(currentTool.toolType).actionPoints);
                                player.playerStamina.SubStamina(toolsData.GetTollWithType(currentTool.toolType).actionPoints);
                                return;
                            }

                        }

                    }
                    break;
                case ToolType.Wither:
                    tiles = GameManager.instance.tilesController.GetTiles(transform.position, currentTool.radius);

                    foreach (Tile tile in tiles)
                    {

                        if (tile.plant.plantState == Plant.PlantState.Remains)
                        {

                            if (resourcesData.money - currentTool.price >= 0)
                            {
                                PlantParameters pp = plantsData.GetPlantWithType(tile.plant.currentPlantType);
                               // GameManager.instance.resourcesController.AddPlantsResource(Random.Range(1, pp.harvestRndMax), tile.plant.currentPlantType);

                                tile.plant.plantState = Plant.PlantState.None;
                                tile.plant.gameObject.SetActive(false);
                                tile.tileType = Tile.TileType.Ground;
                                player.playerAction.AddAction(toolsData.GetTollWithType(currentTool.toolType).actionPoints);
                                player.playerStamina.SubStamina(toolsData.GetTollWithType(currentTool.toolType).actionPoints);
                                return;
                            }

                        }

                    }
                    break;
            }
        }
        #region Events

        public void OnChooseTools(ToolType toolType)
        {
            currentTool = toolsData.GetTollWithType(toolType);
            player.detectionZone.SetRadius(currentTool.radius);
            player.detectionZone.SetColor(currentTool.toolColor);

        }
        public void OnChooseSeed(Plant.PlantType plantType)
        {
            currentPlant = plantsData.GetPlantWithType(plantType);
            toolsData.GetTollWithType(ToolType.Seed).price = currentPlant.price;
            UIManager.instance.toolsUI.SetSeedPrice(currentPlant.price);
            ToolSeed toolSeed = (ToolSeed)toolsData.GetTollWithType(ToolType.Seed);
            
            UIManager.instance.toolsUI.SetSeedSprite(toolSeed.GetSpriteWithType(plantType));
        }
        #endregion


    }
}

