using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Core.UI
{
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField]
        private Slider slider;
        [SerializeField]
        private TMP_Text text;

        public void SetText(string text)
        {
            this.text.text = text;
        }
        /// <summary>
        /// Installation progress
        /// </summary>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <param name="value"></param>
        public void SetProgress(float minValue, float maxValue, float value)
        {
            slider.minValue = minValue;
            slider.maxValue = maxValue;
            slider.value = value;
        }
    }
}


