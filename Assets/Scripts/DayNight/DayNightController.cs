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
        public float incTime = 1;
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
            int tempSec = 0;
            int tempMin = 0;
            while (true)
            {
                yield return new WaitForSeconds(incTime);
                TimeSpan time = TimeSpan.FromSeconds(seconds);
                seconds++;
                tempSec++;
                timerSecond?.Invoke(seconds);
                if (tempSec >= 60)
                {
                    tempSec = 0;
                    tempMin++;
                    timerMinute?.Invoke(time.Minutes);
                    if(tempMin >= 60)
                    {
                        tempMin = 0;
                        
                        timerHour?.Invoke(time.Hours);
                    }
                }
               
                UIManager.instance.dayNightUI.UpdateTimer(time);
               
                             
              
            }

        }


    }
}

