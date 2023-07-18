using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Interfaces;

namespace Core.UI
{
    public class UIManager : MonoBehaviour, Initialize
    {
        [Header("UI Components")]
        public ToolsUI toolsUI;
        public ResourcesUI resourcesUI;
        public DayNightUI dayNightUI;
        public ProgressBar progressBarStamina;

        [Header("Popup")]
        public PopupController popupController;

        public static UIManager instance = null;

        public void Init()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance == this)
            {
                Destroy(gameObject);
            }

            popupController.Init();
            toolsUI.Init();
            resourcesUI.Init();
        }
        public void OnBtnTestClick()
        {
           // popupController.ShowPopup(GameManager.instance.playerController.transform, "2", Popup.Direction.Down, Color.black);
        }

      
    }
}

