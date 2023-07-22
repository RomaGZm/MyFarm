
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
        public ProgressBar progressBarAction;

        [Header("Popup")]
        public PopupController popupController;

        public static UIManager instance = null;

        /// <summary>
        /// Initialize ui components
        /// </summary>
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
            resourcesUI.Init();
        }
      
    }
}

