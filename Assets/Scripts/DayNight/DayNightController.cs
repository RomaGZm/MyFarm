using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Interfaces;
using UnityEngine.Events;
using Core.UI;
using System;

namespace Core.DayNight
{
    public class DayNightController : MonoBehaviour, Initialize
    {
        [Header("Time")]
        public float speed = 1;
        public int seconds = 0;
        public int minutes = 0;
        public int hours = 0;
        [Header("Events")]
        public UnityEvent<int> timerSecond;
        public UnityEvent<int> timerMinute;
        public UnityEvent<int> timerHour;
        public void Init()
        {
            StartCoroutine(Timer());
        }

        private IEnumerator Timer()
        {
            int tempMin = 0;
            int tempHour = 0;
            while (true)
            {
                yield return new WaitForSeconds(speed);
                TimeSpan time = TimeSpan.FromSeconds(seconds);
                seconds++;
                tempMin++;
                timerSecond?.Invoke(seconds);
                if (tempMin >= 60)
                {
                    tempMin = 0;
                    tempHour++;
                    timerMinute?.Invoke(time.Minutes);
                    if(tempHour >= 60)
                    {
                        tempHour = 0;
                        timerHour?.Invoke(time.Hours);
                    }
                }
               
                UIManager.instance.dayNightUI.UpdateTimer(time);
               
                             
              
            }

        }


    }
}

