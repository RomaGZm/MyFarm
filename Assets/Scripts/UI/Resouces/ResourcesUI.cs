
using UnityEngine;
using Core.Interfaces;
using TMPro;

namespace Core.UI
{
    public class ResourcesUI : MonoBehaviour, Initialize
    {
        [Header("Components")]
        public TMP_Text text_money;
        public TMP_Text text_corn;
        public TMP_Text text_melon;
        public TMP_Text text_strawberry;
        [Header("Datas")]
        public ResourcesData resourcesData;
        
        public void Init()
        {
            UpdateResources();
        }

        /// <summary>
        /// Update resources text
        /// </summary>
        public void UpdateResources()
        {
            text_money.text = resourcesData.money.ToString();
            text_corn.text = resourcesData.corn.ToString();
            text_melon.text = resourcesData.melon.ToString();
            text_strawberry.text = resourcesData.strawberry.ToString();
        }

    }
}

