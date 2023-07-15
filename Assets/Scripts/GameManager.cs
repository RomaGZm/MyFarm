using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Tiles;
using Core.Player;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        [Header("Game Controllers")]
        public TilesController tilesController;
        public PlayerController playerController;

        public static GameManager instance = null;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance == this)
            {
                Destroy(gameObject);
            }

            playerController.Init();
        }
    }
}

