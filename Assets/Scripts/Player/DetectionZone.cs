using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Tiles;
using Core.UI;

namespace Core.Player
{
    public class DetectionZone : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField]
        private SpriteRenderer spriteRadius;
        private float currentRadius = 0;

        /// <summary>
        /// Enable display sprite
        /// </summary>
        /// <param name="en"></param>
        public void SetActive(bool en)
        {
            spriteRadius.gameObject.SetActive(en);
        }

        /// <summary>
        /// Setting the radius of the displayed sprite
        /// </summary>
        /// <param name="radius"></param>
        public void SetRadius(float radius)
        {
            currentRadius = radius*2;
            int lvl = GameManager.instance.playerController.playerData.skillsParam.level;
            float zSize = GameManager.instance.playerController.playerData.skillsParam.actionZoneSizePerlevel;
            currentRadius = currentRadius + (lvl * zSize);
            spriteRadius.transform.localScale = new Vector3(currentRadius, currentRadius, 1);
            gameObject.SetActive(true);
        }
        /// <summary>
        /// Set sprite color
        /// </summary>
        /// <param name="color"></param>
        public void SetColor(Color color)
        {
            spriteRadius.color = color;
        }

    
    }
}

