
using UnityEngine;
using Core.UI;
using Core.Plants;

namespace Core.Resources
{
    public class ResourcesController : MonoBehaviour
    {
        [Header("Datas")]
        [SerializeField]
        private ResourcesData resourcesData;

        /// <summary>
        /// Subtract money value and show popup animation
        /// </summary>
        /// <param name="money"></param>
        public void SubMoney(int money)
        {
            resourcesData.money -= money;
            UIManager.instance.resourcesUI.UpdateResources();
                   
            UIManager.instance.popupController.ShowPopup(UIManager.instance.resourcesUI.text_money.transform, "-" + money.ToString(), Popup.Direction.Down, Color.red, new Vector2(-0.1f, 0), new Vector2(0.1f, 0));
      
        }
        /// <summary>
        /// Add money value and show popup animation
        /// </summary>
        /// <param name="money"></param>
        public void AddMoney(int money)
        {
            resourcesData.money += money;
            UIManager.instance.resourcesUI.UpdateResources();
                   
            UIManager.instance.popupController.ShowPopup(UIManager.instance.resourcesUI.text_money.transform, "+" + money.ToString(), Popup.Direction.Down, Color.red, new Vector2(-0.1f, 0), new Vector2(0.1f, 0));
           
        }
        /// <summary>
        /// Subtract resource value and show popup animation
        /// </summary>
        /// <param name="count"></param>
        /// <param name="plantType"></param>
        public void SubPlantsResource(int count, Plant.PlantType plantType)
        {
            Transform ui_panel = null;
            switch (plantType)
            {
                case Plant.PlantType.Corn:
                    ui_panel = UIManager.instance.resourcesUI.text_corn.transform;
                    resourcesData.corn -= count;
                    break;
                case Plant.PlantType.Melon:
                    ui_panel = UIManager.instance.resourcesUI.text_melon.transform;
                    resourcesData.melon -= count;
                    break;
                case Plant.PlantType.Strawberry:
                    ui_panel = UIManager.instance.resourcesUI.text_strawberry.transform;
                    resourcesData.strawberry -= count;
                    break;
            }
          
            UIManager.instance.resourcesUI.UpdateResources();

            UIManager.instance.popupController.ShowPopup(ui_panel, "-" + count.ToString(), Popup.Direction.Down, Color.red, new Vector2(-0.1f, 0), new Vector2(0.1f, 0));

        }
        /// <summary>
        /// Add resource value and show popup animation
        /// </summary>
        /// <param name="count"></param>
        /// <param name="plantType"></param>
        public void AddPlantsResource(int count, Plant.PlantType plantType)
        {
            Transform ui_panel = null;
            switch (plantType)
            {
                case Plant.PlantType.Corn:
                    ui_panel = UIManager.instance.resourcesUI.text_corn.transform;
                    resourcesData.corn += count;
                    break;
                case Plant.PlantType.Melon:
                    ui_panel = UIManager.instance.resourcesUI.text_melon.transform;
                    resourcesData.melon += count;
                    break;
                case Plant.PlantType.Strawberry:
                    ui_panel = UIManager.instance.resourcesUI.text_strawberry.transform;
                    resourcesData.strawberry += count;
                    break;
            }
          
            UIManager.instance.resourcesUI.UpdateResources();

            UIManager.instance.popupController.ShowPopup(ui_panel, "+" + count.ToString(), Popup.Direction.Down, Color.green, new Vector2(-0.1f, 0), new Vector2(0.1f, 0));
          
        }
        /// <summary>
        /// Save resource values and update UI
        /// </summary>
        /// <param name="money"></param>
        /// <param name="corn"></param>
        /// <param name="melon"></param>
        /// <param name="strawberry"></param>
        public void UpdateResources(int money, int corn, int melon, int strawberry)
        {
            resourcesData.money = money;
            resourcesData.money = corn;
            resourcesData.money = melon;
            resourcesData.money = strawberry;

            UIManager.instance.resourcesUI.UpdateResources();
        }
        /// <summary>
        /// Return resouces data
        /// </summary>
        /// <returns></returns>
        public ResourcesData GetResourcesData()
        {
            return resourcesData;
        }
    }
}

