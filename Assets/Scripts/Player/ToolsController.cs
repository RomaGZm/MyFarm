using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Interfaces;
using Core.UI;

namespace Core.Player.Tools{

    [RequireComponent(typeof(PlayerController))]
    public class ToolsController : MonoBehaviour, Initialize
    {
        private PlayerController player;

        public enum ToolType
        {
            Ground, Seed, Watering, Harvest, Wither
        }

        public void Init()
        {
            player = gameObject.GetComponent<PlayerController>();
        }


        #region Events

        public void OnChooseTools(ToolType toolType)
        {
            switch (toolType)
            {
                case ToolType.Ground:
                    player.detectionZone.SetRadius(player.playerData.detectionZoneParam.groundRadius);
                    break;
                case ToolType.Seed:
                    player.detectionZone.SetRadius(player.playerData.detectionZoneParam.seedRadius);
                    break;
                case ToolType.Watering:
                    player.detectionZone.SetRadius(player.playerData.detectionZoneParam.wateringRadius);
                    break;
                case ToolType.Harvest:
                    player.detectionZone.SetRadius(player.playerData.detectionZoneParam.harvestRadius);
                    break;
                case ToolType.Wither:
                    player.detectionZone.SetRadius(player.playerData.detectionZoneParam.wateringRadius);
                    break;
            }
        }
        #endregion

      
    }
}

