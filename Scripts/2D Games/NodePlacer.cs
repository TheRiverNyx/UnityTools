using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
[ExecuteInEditMode]
public class NodePlacer : MonoBehaviour
{
    public GameObject nodeRoot;
    public Tilemap tilemap;
    public void Scan()
    {
        BoundsInt bounds = tilemap.cellBounds;
        for (int x = bounds.xMin; x < bounds.xMax; x++)
        {
            for (int y = bounds.yMin; y < bounds.yMax; y++)
            {
                Vector3Int currentPos = new Vector3Int(x, y, 0);
                if (tilemap.GetTile(currentPos + Vector3Int.down) != null && tilemap.GetTile(currentPos) == null)
                {
                    GameObject newTileObject = new GameObject("Tile_" + x + "_" + y);
                    newTileObject.tag = "Pathfinding Node";
                    newTileObject.transform.parent = nodeRoot.transform;
                    newTileObject.transform.position = tilemap.GetCellCenterWorld(currentPos);
                }
            }
        }
    }
}