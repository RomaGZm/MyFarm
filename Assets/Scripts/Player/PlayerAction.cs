
using UnityEngine;
using Core.Interfaces;
using Core.UI;
using UnityEngine.Events;

namespace Core.Player
{
    public class PlayerAction : MonoBehaviour, Initialize
    {
        [SerializeField]
        private PlayerController playerController;

        [Header("Events")]
        public UnityEvent<int> nextLvlEvent;

        public void Init()
        {
            UIManager.instance.progressBarAction.SetText(playerController.playerData.skillsParam.level.ToString());
        }
        /// <summary>
        /// Çlayer action, adding experience
        /// </summary>
        /// <param name="actionPoints"></param>
        public void AddAction(int actionPoints)
        {
            int nextLvl = playerController.playerData.skillsParam.actionNexLevel;
           
            playerController.playerData.skillsParam.actionPoints += actionPoints;
            int ap = playerController.playerData.skillsParam.actionPoints;

            if(ap >= nextLvl)
            {
                if(playerController.playerData.skillsParam.level < 5)
                {
                    playerController.playerData.skillsParam.level++;
                    playerController.playerData.skillsParam.actionPoints = 0;
                    UIManager.instance.progressBarAction.SetText(playerController.playerData.skillsParam.level.ToString());
                    nextLvlEvent?.Invoke(playerController.playerData.skillsParam.level);
                   
                }
                else
                {
                    UIManager.instance.progressBarAction.SetText("Max");
                    nextLvlEvent?.Invoke(playerController.playerData.skillsParam.level);
                }
              
            }
            
            UIManager.instance.progressBarAction.SetProgress(0, nextLvl, playerController.playerData.skillsParam.actionPoints);
            UIManager.instance.popupController.ShowPopup(UIManager.instance.progressBarAction.transform, "+" + actionPoints.ToString(), Popup.Direction.Down, Color.green,
                new Vector2(-0.1f, 0), new Vector2(0.1f, 0));
        }
    }
}

