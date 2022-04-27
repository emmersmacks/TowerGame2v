using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class TilemapPainter : MonoBehaviour
{
    public Tile tile;
    public Tilemap map;

    public void FilledBoxMap(int width, int height)
    {
        var tileWidth = width * 3 -1;
        var tileHeight = height * 3 -1;
        map.SetTile(new Vector3Int(tileWidth, tileHeight, 0), tile);
        map.SetTile(new Vector3Int(0, 0, 0), tile);
        map.BoxFill(new Vector3Int(0, 0, 0), null, 0, 0, tileWidth, tileHeight);
        map.BoxFill(new Vector3Int(0, 0, 0), tile, 0, 0, tileWidth, tileHeight);

    }
}
