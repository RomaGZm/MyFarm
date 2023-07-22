using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Plants
{
    public class PlantProgressBar : MonoBehaviour
    {
        [SerializeField]
        private Transform fullSprite;
        [SerializeField]
        private Transform fillSprite;
        public float offsetY = 0.5f;

        void Start()
        {
            Vector3 newScale = fillSprite.localScale;
            newScale.y = 0;
            fillSprite.localScale = newScale;
        }
        private float value = 0;
        private float maxValue = 0;
        public void SetFillColor(Color color)
        {
            fillSprite.GetComponent<SpriteRenderer>().color = color;
        }
        public void SetValue(float value)
        {
            this.value = value;

            SetFillBar(value / maxValue);
        }
        public void SetMaxValue(float max)
        {
            maxValue = max;
        }
        public void SetFillBar(float fillAmount)
        {
          
            fillAmount = Mathf.Clamp01(fillAmount);
          
            Vector3 newScale = fillSprite.localScale;
            newScale.y = fullSprite.localScale.y * fillAmount;
            fillSprite.localScale = newScale;
            fillSprite.localPosition = new Vector3(fillSprite.localPosition.x, (fillAmount/2) - offsetY, fillSprite.localPosition.z);
        }
     
    }



}
