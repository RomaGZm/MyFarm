using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Interfaces;

namespace Core.Tiles
{
    public class TilesController : MonoBehaviour, Initialize
    {
        [Header("Tiles")]
        [SerializeField]
        private List<Tile> tiles;

        [Header("Data")]
        public TileData tileData;

        public void Init()
        {
            foreach(Tile tile in tiles)
            {
                tile.Init();
            }
        }

        public List<Tile> GetTiles(Vector2 pos, float radius)
        {
            List<Tile> ret = new List<Tile>();
            Collider2D[] cols =  Physics2D.OverlapCircleAll(pos, radius, LayerMask.GetMask("Tiles"));
            foreach(Collider2D col in cols)
            {
                ret.Add(col.GetComponent<Tile>());

            }
            return ret;
        }
       

    }
}

