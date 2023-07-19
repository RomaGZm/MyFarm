using System.Collections;
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
        

        private PlayerController player;
        private ToolParameters currentTool;
        private PlantParameters currentPlant;
        public enum ToolType
        {
            Ground, Seed, Watering, Harvest, Wither
        }

        public void Init()
        {
            player = gameObject.GetComponent<PlayerController>();
            currentTool = toolsData.GetTollWithType(ToolType.Ground);
            UIManager.instance.toolsUI.SetSelected(ToolType.Ground);

            UIManager.instance.toolsUI.UpdateToolsPrice(toolsData.GetTollWithType(ToolType.Ground).price, toolsData.GetTollWithType(ToolType.Seed).price,
                toolsData.GetTollWithType(ToolType.Watering).price, toolsData.GetTollWithType(ToolType.Harvest).price, toolsData.GetTollWithType(ToolType.Wither).price);

            currentPlant = plantsData.GetPlantWithType(Plant.PlantType.Corn);
            UIManager.instance.toolsUI.SetSelected(Plant.PlantType.Corn);
            UIManager.instance.toolsUI.UpdateSeedPrice(plantsData.GetPlantWithType(Plant.PlantType.Corn).price, plantsData.GetPlantWithType(Plant.PlantType.Melon).price, 
                plantsData.GetPlantWithType(Plant.PlantType.Strawberry).price);
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
                        print(tile.tileType);
                        if (tile.tileType == Tile.TileType.Sand)
                        {
                            
                            if(resourcesData.money - currentTool.price >= 0)
                            {
                                GameManager.instance.resourcesController.SubMoney(currentTool.price);
                                tile.tileType = Tile.TileType.Ground;
                                return;
                            }
                           
                        }
                        
                    }
                    break;
                case ToolType.Seed:
                    tiles = GameManager.instance.tilesController.GetTiles(transform.position, currentTool.radius);
                    print(resourcesData.money + "   " + currentTool.price);
                    foreach (Tile tile in tiles)
                    {
                       
                        if (tile.tileType == Tile.TileType.Ground && !tile.plant.gameObject.activeSelf)
                        {

                            if (resourcesData.money - currentTool.price >= 0)
                            {
                                
                                GameManager.instance.resourcesController.SubMoney(currentTool.price);
                              
                                tile.plant.currentPlantType = currentPlant.plantType;
                                tile.plant.Enable(true);
                                return;
                            }

                        }

                    }
                    break;
                case ToolType.Watering:
                    //  player.detectionZone.SetRadius(player.playerData.detectionZoneParam.wateringRadius);
                    break;
                case ToolType.Harvest:
                    // player.detectionZone.SetRadius(player.playerData.detectionZoneParam.harvestRadius);
                    break;
                case ToolType.Wither:
                    // player.detectionZone.SetRadius(player.playerData.detectionZoneParam.wateringRadius);
                    break;
            }
        }
        #region Events

        public void OnChooseTools(ToolType toolType)
        {
            currentTool = toolsData.GetTollWithType(toolType);
            player.detectionZone.SetRadius(currentTool.radius);

        }
        public void OnChooseSeed(Plants.Plant.PlantType plantType)
        {
            currentPlant = plantsData.GetPlantWithType(plantType);
            toolsData.GetTollWithType(ToolType.Seed).price = currentPlant.price;
            UIManager.instance.toolsUI.SetSeedPrice(currentPlant.price);

        }
        #endregion


    }
}

