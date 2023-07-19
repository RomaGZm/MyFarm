using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Core.UI
{
    public class Popup : MonoBehaviour
    {


        public enum Direction
        {
            Up, Down
        }

        [Header("Amimation Settings")]
        public float animFromValue = 0;
        public float animToValue = 1;
        public float speed = 0.3f;

        public float scaleFromValue = 0.1f;
        public float scaleToValue = 1f;
        public float scaleSpeed = 0.3f;
        [Header("Components")]
        [SerializeField]
        private TMP_Text tmp_text;

        private float currentValue = 0;
        private float currentScaleValue = 0;
        private Transform target;
        private Vector2 rondom_ = Vector2.zero;
        private Direction direction = Direction.Up;



        private void OnEnable()
        {
           

        }
        private void Update()
        {
            if (target == null) return;

            if (direction == Direction.Up)
                currentValue = Mathf.MoveTowards(currentValue, animToValue, speed * Time.deltaTime);
            else
                currentValue = Mathf.MoveTowards(currentValue, -animToValue, speed * Time.deltaTime);
            currentScaleValue = Mathf.MoveTowards(currentScaleValue, scaleToValue, scaleSpeed * Time.deltaTime);
            transform.localScale = new Vector3(currentScaleValue, currentScaleValue, currentScaleValue);


            Vector3 newPos = new Vector3(target.position.x, target.position.y + currentValue, target.position.z); //Camera.main.WorldToScreenPoint(new Vector3(target.position.x, target.position.y + currentValue, target.position.z)); 

            transform.position = new Vector3(newPos.x + rondom_.x, newPos.y + rondom_.y, 0); 
        }
        IEnumerator Disable(float waitSec)
        {
            yield return new WaitForSeconds(waitSec);
           
            currentValue = animFromValue;
            gameObject.SetActive(false);
        }
        public void Show(Transform target, string text, Direction direction, Color textColor, Vector2 randomMinValues, Vector2 randomMaxValues)
        {

            currentScaleValue = scaleFromValue;
            transform.localScale = new Vector3(currentScaleValue, currentScaleValue, currentScaleValue);
            this.direction = direction;
            currentValue = animFromValue;
            this.target = target;
            
            rondom_.x += Random.Range(randomMinValues.x, randomMaxValues.x);
            rondom_.y += Random.Range(randomMinValues.y, randomMaxValues.y);
        
            tmp_text.text = text;
            tmp_text.color = textColor;
            gameObject.SetActive(true);
            StartCoroutine(Disable(1f));
        }


    }

}
