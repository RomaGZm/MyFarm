using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.UI;
using Core.Interfaces;

namespace Core.Player
{
  
    public class PlayerStamina : MonoBehaviour, Initialize
    {
        private float _staminaCurrent;
        public float staminaCurrent
        {
            get { return _staminaCurrent; }
            set 
            { 
                _staminaCurrent = value;
                UpdateProgress();
            }
        }
        [Header("Player")]
        [SerializeField]
        private PlayerController playerController;

        [Header("Popup Animation Settings")]
        [SerializeField]
        private Vector3 offsetAnimSubStamina;
        [SerializeField]
        private Vector3 offsetAnimAddStamina;
        [SerializeField]
        private Vector2 randomMinAddStamina;
        [SerializeField]
        private Vector2 randomMinSubStamina;
        [SerializeField]
        private Vector2 randomMaxAddStamina;
        [SerializeField]
        private Vector2 randomMaxSubStamina;

        public void Init()
        {
           
            staminaCurrent = playerController.playerData.staminaParam.staminaMax;
       
        }
        /// <summary>
        /// Update UI Progress Bar
        /// </summary>
        public void UpdateProgress()
        {
            UIManager.instance.progressBarStamina.SetProgress(playerController.playerData.staminaParam.staminaMin, playerController.playerData.staminaParam.staminaMax, staminaCurrent);
        }
        /// <summary>
        /// Set stamina value and show popup animation
        /// </summary>
        /// <param name="value"></param>
        public void SubStamina(float value)
        {
            if (staminaCurrent - value < 0)
                staminaCurrent = 0;
            else
            {
                float er = playerController.playerData.staminaParam.walkEnergyLoss_min;
              
                UIManager.instance.popupController.ShowPopup(UIManager.instance.progressBarStamina.transform, "- " + er.ToString(), Popup.Direction.Down, Color.red, randomMinSubStamina, randomMaxSubStamina);
                staminaCurrent -= value;
            }
                
        }
        /// <summary>
        /// Add stamina value and show popup animation
        /// </summary>
        /// <param name="value"></param>
        public void AddStamina(float value)
        {
            if (staminaCurrent + value > playerController.playerData.staminaParam.staminaMax)
                staminaCurrent = playerController.playerData.staminaParam.staminaMax;
            else
            {
                float er = playerController.playerData.staminaParam.walkEnergyRecovery_min;
        
                UIManager.instance.popupController.ShowPopup(UIManager.instance.progressBarStamina.transform, "+ " + er.ToString(), Popup.Direction.Down, Color.green, randomMinAddStamina, randomMaxAddStamina);
                staminaCurrent += value;
            }
               
        }
        #region Events
        public void OnTimerSecond(int hours)
        {
            if (playerController.isMove)
            {
               // SubStamina(playerController.playerData.staminaParam.walkEnergyLoss_min);
            }
            else
            {
                
              //  AddStamina(playerController.playerData.staminaParam.walkEnergyRecovery_min);
            
            }
       
        }
        public void OnTimerMinute(int mins)
        {

            if (playerController.isMove)
            {
                SubStamina(playerController.playerData.staminaParam.walkEnergyLoss_min);
            }
            else
            {
                AddStamina(playerController.playerData.staminaParam.walkEnergyRecovery_min);
            }
          
          
        }
        public void OnTimerHour(int hours)
        {

        }
        #endregion

    }
}

