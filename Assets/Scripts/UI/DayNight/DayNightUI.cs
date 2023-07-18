using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

namespace Core.UI
{
    public class DayNightUI : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField]
        private Image imageDayNight;
        [SerializeField]
        private TMP_Text textTime;

        [Header("Sprites")]
        [SerializeField]
        private Sprite spriteDay;
        [SerializeField]
        private Sprite spriteNight;



        public void UpdateTimer(TimeSpan time)
        {

            textTime.text = time.ToString();
        }
      
    }

}
