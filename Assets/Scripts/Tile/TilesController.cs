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
        public PlantsData plantsData;

        public void Init()
        {
            foreach(Tile tile in tiles)
            {
                tile.Init();
            }
        }

        public List<Tile> GetTiles(Vector2 pos, float radius)
        {
            int lvl = GameManager.instance.playerController.playerData.skillsParam.level;
            float zSize = GameManager.instance.playerController.playerData.skillsParam.actionZoneSizePerlevel;
            float newRadius = radius + ((lvl * zSize)/2);
            print(newRadius);
            List<Tile> ret = new List<Tile>();
            Collider2D[] cols =  Physics2D.OverlapCircleAll(pos, newRadius, LayerMask.GetMask("Tiles"));
            foreach(Collider2D col in cols)
            {
                ret.Add(col.GetComponent<Tile>());

            }
            return ret;
        }
       

    }
}

