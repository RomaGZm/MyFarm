
using UnityEngine;
using UnityEngine.UI;
using Core.UI;
using Core.Plants;
using TMPro;

namespace Core.Resources
{
    public class Shop : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField]
        private Image imagePlant;
        [SerializeField]
        private Slider sliderPlantPrice;
        [SerializeField]
        private TMP_Text text_plants;
        [SerializeField]
        private TMP_Text text_price;

        private Plant.PlantType currentPlant = Plant.PlantType.Corn;
        [Header("Sprites")]
        [SerializeField]
        private Sprite spriteUICorn;
        [SerializeField]
        private Sprite spriteUIMelon;
        [SerializeField]
        private Sprite spriteUIStrawberry;

        public void Show(int plantType)
        {
            switch (plantType)
            {
                case (int)Plant.PlantType.Corn:
                    imagePlant.sprite = spriteUICorn;
                    break;
                case (int)Plant.PlantType.Melon:
                    imagePlant.sprite = spriteUIMelon;
                    break;
                case (int)Plant.PlantType.Strawberry:
                    imagePlant.sprite = spriteUIStrawberry;
                    break;
            }
            
            currentPlant = (Plant.PlantType)plantType;
            UpdateSliderValues();
           
            gameObject.SetActive(true);
        }

        private void UpdateSliderValues()
        {
            ResourcesData resData = GameManager.instance.resourcesController.GetResourcesData();

            switch (currentPlant)
            {
                case Plant.PlantType.Corn:
                    sliderPlantPrice.maxValue = resData.corn;
                    sliderPlantPrice.value = resData.corn;
                    break;
                case Plant.PlantType.Melon:
                    sliderPlantPrice.maxValue = resData.melon;
                    sliderPlantPrice.value = resData.melon;
                    break;
                case Plant.PlantType.Strawberry:
                    sliderPlantPrice.maxValue = resData.strawberry;
                    sliderPlantPrice.value = resData.strawberry;
                    break;
            }
            
        }
        #region events
        /// <summary>
        /// Slider price event, when changing values
        /// </summary>
        public void OnValueChange()
        {
            text_plants.text = ((int)sliderPlantPrice.value).ToString();
            text_price.text = "= " + ((int)sliderPlantPrice.value * GameManager.instance.tilesController.plantsData.GetPlantWithType(currentPlant).price);

        }
        /// <summary>
        /// Button buy click event
        /// </summary>
        public void OnBtnBuyClick()
        {
            ResourcesData resData = GameManager.instance.resourcesController.GetResourcesData();
            if (resData.corn <= 0) return;

            GameManager.instance.resourcesController.AddMoney((int)sliderPlantPrice.value);
            GameManager.instance.resourcesController.SubPlantsResource((int)sliderPlantPrice.value, currentPlant);
            UIManager.instance.resourcesUI.UpdateResources();

            UpdateSliderValues();
        }
        public void OnBtnCanñelClick()
        {
            gameObject.SetActive(false);
        }
       
        #endregion

    }
}

