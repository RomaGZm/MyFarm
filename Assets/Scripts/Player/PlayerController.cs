using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Interfaces;
using Core.Player.Tools;
using Core.UI;

namespace Core.Player
{
    public class PlayerController : MonoBehaviour, Initialize
    {

        [Header("Components")]
        [SerializeField]
        private Rigidbody2D rb2D;
        [Header("Controllers")]
        [SerializeField]
        private PlayerAnimation playerAnimation;
        [SerializeField]
        private ToolsController toolsController;

        public DetectionZone detectionZone;
        public PlayerStamina playerStamina;
        public PlayerAction playerAction;

        [Header("Datas")]
        public PlayerData playerData;
        [Header("Move")]
        public float moveSpeed = 1;
        public bool isMove = false;

        private Vector3 movement = Vector3.zero;

        public void Init()
        {
            toolsController.Init();
            playerStamina.Init();
            playerAction.Init();
        }

       
        private void Update()
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            playerAnimation.Walk(v);
            movement = new Vector3(h, v, 0).normalized;

            if (Input.GetKeyDown(playerData.inputParam.keyAction))
             {
                toolsController.ToolAction();
               
             }
        }

        private void FixedUpdate()
        {
            Move(movement); 
            isMove = rb2D.velocity.magnitude > 0;
        }

        
        private void Move(Vector3 direction)
        {
    
            rb2D.velocity = direction * moveSpeed * Time.fixedDeltaTime;
        }
        #region events

        /// <summary>
        /// Called when a player's level increases.
        /// </summary>
        public void OnNextLevel()
        {

            detectionZone.SetRadius(toolsController.currentTool.radius);
        }
        #endregion
    }
}

