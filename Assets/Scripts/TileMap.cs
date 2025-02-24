using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMap : MonoBehaviour
{
    public bool IsTileAt(Tilemap tilemap, Vector3 worldPosition)
    {
        Vector3Int cellPosition = tilemap.WorldToCell(worldPosition);
        TileBase tile = tilemap.GetTile(cellPosition);

        return tile != null; // Returns true if there is a tile, false otherwise
    }

    public string GetTileName(Tilemap tilemap, Vector3 worldPosition)
    {
        Vector3Int cellPosition = tilemap.WorldToCell(worldPosition);
        TileBase tile = tilemap.GetTile(cellPosition);

        return tile != null ? tile.name : "No Tile";
    }
}
