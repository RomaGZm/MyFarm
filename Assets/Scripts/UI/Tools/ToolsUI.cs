using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Interfaces;
using UnityEngine.Events;
using System;
using Core.Player.Tools;
using Core.Plants;

namespace Core.UI
{
    public class ToolsUI : MonoBehaviour, Initialize
    {

        [Header("Buttons")]
        [SerializeField]
        private ButtonTool btnGround;
        [SerializeField]
        private ButtonTool btnSeed;
        [SerializeField]
        private ButtonTool btnWatering;
        [SerializeField]
        private ButtonTool btnHarvest;
        [SerializeField]
        private ButtonTool btnWither;
        [SerializeField]
        private ButtonTool btnCorn;
        [SerializeField]
        private ButtonTool btnMelon;
        [SerializeField]
        private ButtonTool btnStrawberry;
        [Header("Other")]
        [SerializeField]
        private GameObject panelSeed;

        [Header("Events")]

        public UnityEvent<ToolsController.ToolType> btnToolClick;
        public UnityEvent<Plant.PlantType> btnSeedClick;

        public void Init()
        {
           
        }
        public void SetSelected(ToolsController.ToolType toolType)
        {
            switch (toolType)
            {
                case ToolsController.ToolType.Ground:
                    btnGround.isSelected = true;
                    break;
                case ToolsController.ToolType.Seed:
                    btnSeed.isSelected = true;
                    break;
                case ToolsController.ToolType.Watering:
                    btnWatering.isSelected = true;
                    break;
                case ToolsController.ToolType.Harvest:
                    btnHarvest.isSelected = true;
                    break;
                case ToolsController.ToolType.Wither:
                    btnStrawberry.isSelected = true;
                    break;
            }

        }
        public void SetSelected(Plant.PlantType plantType)
        {
            switch (plantType)
            {
                case Plant.PlantType.Corn:
                    btnCorn.isSelected = true;
                    break;
                case Plant.PlantType.Melon:
                    btnMelon.isSelected = true;
                    break;
                case Plant.PlantType.Strawberry:
                    btnGround.isSelected = true;
                    break;
            }

        }
        public void UpdateToolsPrice(int ground, int seed, int watering, int harvest,int wither)
        {
            btnGround.SetPrice(ground);
            btnSeed.SetPrice(seed);
            btnWatering.SetPrice(watering);
            btnHarvest.SetPrice(harvest);
            btnWither.SetPrice(wither);
        }
        public void UpdateSeedPrice(int corn, int melon, int strawberry)
        {
            btnCorn.SetPrice(corn);
            btnMelon.SetPrice(melon);
            btnStrawberry.SetPrice(strawberry);
        }
        public void SetSeedPrice(int price)
        {
            btnSeed.SetPrice(price);
        }
        private void ResetSelectedButtons()
        {
            btnGround.isSelected = false;
            btnSeed.isSelected = false;
            btnWatering.isSelected = false;
            btnHarvest.isSelected = false;
            btnWither.isSelected = false;
            panelSeed.SetActive(false);
        }

        #region Events

        public void OnBtnToolClick(int toolType)
        {
            ResetSelectedButtons();
            switch (toolType)
            {
                case (int)ToolsController.ToolType.Ground:
                    btnGround.isSelected = true;
                    break;
                case (int)ToolsController.ToolType.Seed:
                   
                    btnSeed.isSelected = true;
                    panelSeed.SetActive(true);
                    break;
                case (int)ToolsController.ToolType.Watering:
                  
                    btnWatering.isSelected = true;
                    break;
                case (int)ToolsController.ToolType.Harvest:
                   
                    btnHarvest.isSelected = true;
                    break;
                case (int)ToolsController.ToolType.Wither:
                 
                    btnWither.isSelected = true;
                    break;
            }
            btnToolClick?.Invoke((ToolsController.ToolType)toolType);
        }

        private void ResetSeedButtons()
        {
            btnCorn.isSelected = false;
            btnMelon.isSelected = false;
            btnStrawberry.isSelected = false;
        }
        public void OnBtnSeedClick(int seedType)
        {
            ResetSeedButtons();
            switch (seedType)
            {
                case (int)Plant.PlantType.Corn:
                    btnCorn.isSelected = true;
                    break;
                case (int)Plant.PlantType.Melon:
                    btnMelon.isSelected = true;
                    break;
                case (int)Plant.PlantType.Strawberry:
                    btnStrawberry.isSelected = true;
                    break;
            }
            btnSeedClick?.Invoke((Plant.PlantType)seedType);
        }
        #endregion
    }
}

