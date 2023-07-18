using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Interfaces;
using Core.UI;

namespace Core.Resources
{
    public class ResourcesController : MonoBehaviour, Initialize
    {
        [Header("Datas")]
        [SerializeField]
        private ResourcesData resourcesData;

        public void Init()
        {
           
        }

        public void UpdateResources(int money, int corn, int melon, int strawberry)
        {
            resourcesData.money = money;
            resourcesData.money = corn;
            resourcesData.money = melon;
            resourcesData.money = strawberry;

            UIManager.instance.resourcesUI.UpdateResources();
        }
        public ResourcesData GetResourcesData()
        {
            return resourcesData;
        }
    }
}

