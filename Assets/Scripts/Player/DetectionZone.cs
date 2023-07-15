using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Tiles;

namespace Core.Player
{
    public class DetectionZone : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField]
        private SpriteRenderer spriteRadius;

        public void SetActive(bool en)
        {
            spriteRadius.gameObject.SetActive(en);
        }
        public void SetRadius(float radius)
        {
            spriteRadius.transform.localScale = new Vector3(radius, radius, 1);
        }
        public void SetColor(Color color)
        {
            spriteRadius.color = color;
        }

        public void GetCurrentTile()
        {
          List<Tile> tiles =  GameManager.instance.tilesController.GetTiles(transform.position, 1);

            foreach (Tile tile in tiles)
            {
                print(tile);
                tile.tileType = Tile.TileType.Ground;
            }
              
           
        }
    }
}

