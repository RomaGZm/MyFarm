using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Interfaces;
using UnityEngine.UI;
using TMPro;

namespace Core.UI
{
    public class ResourcesUI : MonoBehaviour, Initialize
    {
        [Header("Components")]
        [SerializeField]
        private TMP_Text text_money;
        [SerializeField]
        private TMP_Text text_corn;
        [SerializeField]
        private TMP_Text text_melon;
        [SerializeField]
        private TMP_Text text_strawberry;
        [Header("Datas")]
        [SerializeField]
        private ResourcesData resourcesData;
        public void Init()
        {
            UpdateResources();
        }

        public void UpdateResources()
        {
            text_money.text = resourcesData.money.ToString();
            text_corn.text = resourcesData.corn.ToString();
            text_melon.text = resourcesData.melon.ToString();
            text_strawberry.text = resourcesData.strawberry.ToString();
        }

    }
}

