using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Tilemaps;

public class GridHelper : MonoBehaviour
{
   public Tilemap[] tilemaps;


    void Start()
    {
        DisplayTilePositions();
    }
    public void ClearGrid()
    {
        foreach (Tilemap tilemap in tilemaps)
        {
            tilemap.ClearAllTiles();
        }
    }

    public void SetTile(Vector3Int position, TileBase tile)
    {
        foreach (Tilemap tilemap in tilemaps)
        {
            tilemap.SetTile(position, tile);
        }
    }

    public void SetTiles(Vector3Int[] positions, TileBase tile)
    {
        foreach (Tilemap tilemap in tilemaps)
        {
            foreach (Vector3Int position in positions)
            {
                tilemap.SetTile(position, tile);
            }
        }
    }


    public void DisplayTilePositions()
    {
        foreach (Tilemap tilemap in tilemaps)
        {
            foreach (Vector3Int position in tilemap.cellBounds.allPositionsWithin)
            {
                if (tilemap.HasTile(position))
                {
                    // Draw label
                    Vector3 worldPosition = tilemap.CellToWorld(position);
                    Vector3 labelPosition = new Vector3(worldPosition.x + 0.5f, worldPosition.y + 0.5f, worldPosition.z);
                    GameObject label = new GameObject("Label");
                    label.transform.position = labelPosition;
                    label.transform.parent = tilemap.transform;
                    TextMesh textMesh = label.AddComponent<TextMesh>();
                    textMesh.text = position.ToString();
                    textMesh.fontSize = 10;

                }
            }
        }
    }
    


}
