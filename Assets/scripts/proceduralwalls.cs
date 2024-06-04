using UnityEngine;
using UnityEngine.Tilemaps;

public class ProceduralWallsGenerator : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase leftWallTile;  // Single tile for the left wall
    public TileBase rightWallTile; // Single tile for the right wall

    public int mapHeight = 10;

    void Start()
    {
        GenerateWalls();
    }

    void GenerateWalls()
    {
        // Ensure the Tilemap is not null
        if (tilemap == null)
        {
            Debug.LogError("Tilemap is not assigned!");
            return;
        }

        for (int y = 0; y < mapHeight; y++)
        {
            // Set the left wall tile at position (0, y)
            Vector3Int leftTilePosition = new Vector3Int(0, y, -1);
            tilemap.SetTile(leftTilePosition, leftWallTile);

            // Set the right wall tile at position (24, y)
            Vector3Int rightTilePosition = new Vector3Int(24, y, 0); // Assuming the right wall is at position 24
            tilemap.SetTile(rightTilePosition, rightWallTile);
        }
    }
}
