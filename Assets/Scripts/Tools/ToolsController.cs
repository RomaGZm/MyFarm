using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Interfaces;
using Core.Tiles;
using Core.UI;

namespace Core.Player.Tools{

    [RequireComponent(typeof(PlayerController))]
    public class ToolsController : MonoBehaviour, Initialize
    {
        [Header("Datas")]
        [SerializeField]
        private ToolsData toolsData;

        private PlayerController player;
        private ToolParameters currentTool;
        public enum ToolType
        {
            Ground, Seed, Watering, Harvest, Wither
        }

        public void Init()
        {
            player = gameObject.GetComponent<PlayerController>();
            currentTool = toolsData.GetTollWithType(ToolType.Ground);
            UIManager.instance.toolsUI.UpdateToolsPrice(toolsData.GetTollWithType(ToolType.Ground).price, toolsData.GetTollWithType(ToolType.Seed).price,
                toolsData.GetTollWithType(ToolType.Watering).price, toolsData.GetTollWithType(ToolType.Harvest).price, toolsData.GetTollWithType(ToolType.Wither).price);
        }

        public void ToolAction()
        {
            switch (currentTool.toolType)
            {
                case ToolType.Ground:
                    List<Tile> tiles = GameManager.instance.tilesController.GetTiles(transform.position, 1);

                    foreach (Tile tile in tiles)
                    {
                        if (tile.tileType == Tile.TileType.Sand)
                        {
                            tile.tileType = Tile.TileType.Ground;
                        }
                        
                    }
                    break;
                case ToolType.Seed:
                    // player.detectionZone.SetRadius(player.playerData.detectionZoneParam.seedRadius);
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
        #endregion

      
    }
}

