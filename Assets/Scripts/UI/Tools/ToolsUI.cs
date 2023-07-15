using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Interfaces;
using UnityEngine.Events;
using System;
using Core.Player.Tools;

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
        [Header("Events")]
        public UnityEvent<ToolsController.ToolType> btnToolClick;
        public void Init()
        {
           
        }

        private void ResetSelectedButtons()
        {
            btnGround.isSelected = false;
            btnSeed.isSelected = false;
            btnWatering.isSelected = false;
            btnHarvest.isSelected = false;
            btnWither.isSelected = false;
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

        #endregion
    }
}

