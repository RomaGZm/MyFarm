using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Core.UI
{
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField]
        private Slider slider;
      
        public void SetProgress(float minValue, float maxValue, float value)
        {
            slider.minValue = minValue;
            slider.minValue = maxValue;
            slider.value = value;
        }
    }
}


