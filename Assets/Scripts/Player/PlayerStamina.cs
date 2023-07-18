using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.UI;
using Core.Interfaces;

namespace Core.Player
{
    [RequireComponent(typeof(PlayerController))]
    public class PlayerStamina : MonoBehaviour, Initialize
    {

        public float staminaCurrent
        {
            get { return _staminaCurrent; }
            set 
            { 
                _staminaCurrent = value;
                UpdateProgress();
            }
        }
        private float _staminaCurrent;
        private PlayerController playerController;

        public void Init()
        {
            playerController.GetComponent<PlayerController>();
            staminaCurrent = playerController.playerData.staminaParam.staminaMax;
       
        }

        public void UpdateProgress()
        {
            UIManager.instance.progressBarStamina.SetProgress(playerController.playerData.staminaParam.staminaMin, playerController.playerData.staminaParam.staminaMax, staminaCurrent);
        }

        public void OnTimerMinute(int min)
        {

        }
        public void OnTimerHour(int min)
        {

        }
    }
}

