using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Interfaces;
using Core.Player.Tools;

namespace Core.Player
{
    public class PlayerController : MonoBehaviour, Initialize
    {

        [Header("Components")]
        [SerializeField]
        private Rigidbody2D rb2D;
        [SerializeField]
        private PlayerAnimation playerAnimation;
        [SerializeField]
        private ToolsController toolsController;
        public DetectionZone detectionZone;
        [Header("Datas")]
        public PlayerData playerData;
        [Header("Move")]
        public float moveSpeed = 1;

        public void Init()
        {
            toolsController.Init();
        }

        
        void Update()
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            playerAnimation.Walk(v);
            Vector3 vect = new Vector3(h, v, 0);
            vect = vect.normalized * moveSpeed * Time.deltaTime;
            rb2D.MovePosition(rb2D.transform.position + vect);
        }

     
    }
}

