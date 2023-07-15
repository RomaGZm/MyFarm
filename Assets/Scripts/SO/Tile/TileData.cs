using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Tiles;

[CreateAssetMenu(fileName = "TileData", menuName = "SO/TileData", order = 1)]
public class TileData : ScriptableObject
{
    [System.Serializable]
    public class TileSprites
    {
        public Sprite sand;
        public Sprite grass;
        public Sprite ground;

    }
    [Header("Tile sprites")]
    public TileSprites tileSprites;


    public Sprite GetTileSprite(Tile.TileType tileType)
    {
        switch (tileType)
        {
           
            case Tile.TileType.Grass:
                return tileSprites.grass;
            case Tile.TileType.Ground:
                return tileSprites.ground;
            case Tile.TileType.Sand:
                return tileSprites.sand;
             
        }
        return null;
    }
}
