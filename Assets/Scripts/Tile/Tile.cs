using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Interfaces;
using Core.Plants;

namespace Core.Tiles
{
    public class Tile : MonoBehaviour, Initialize
    {
        public enum TileType
        {
            None, Sand, Ground, Grass
        }

        private TileType tileType_;

        public TileType tileType
        {
            get { return tileType_; }
            set 
            { 
                tileType_ = value;
                spriteRenderer.sprite = GameManager.instance.tilesController.tileData.GetTileSprite(tileType);
            }
        }
       
        [Header("Components")]
        [SerializeField]
        private SpriteRenderer spriteRenderer;
        public Plant plant;


        public void Init()
        {
            tileType = TileType.Sand;
            plant?.Init();
        }

       

    }

}

