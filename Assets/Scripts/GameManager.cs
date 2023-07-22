using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Tiles;
using Core.Player;
using Core.UI;
using Core.DayNight;
using Core.Resources;
using Core.Cameras;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        [Header("Game Controllers")]
        public TilesController tilesController;
        public PlayerController playerController;
        public DayNightController dayNightController;
        public ResourcesController resourcesController;
        public FollowCamera followCamera;

        [Header("UI")]
        [SerializeField]
        private UIManager uIManager;

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
            uIManager.Init();
            tilesController.Init();
            playerController.Init();
            dayNightController.Init();
            followCamera.Init();


        }
    }
}

