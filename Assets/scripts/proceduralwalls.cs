using UnityEngine;
using UnityEngine.Tilemaps;

public class ProceduralWallsGenerator : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase[] leftTilesSection1;
    public TileBase[] rightTilesSection1;
    public TileBase[] leftTilesSection2;
    public TileBase[] rightTilesSection2;
    public TileBase[] leftTilesSection3;
    public TileBase[] rightTilesSection3;

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
            // Determine which section this row belongs to based on its y-coordinate
            int sectionIndex = y / (mapHeight / 3); // Assuming equal height sections

            // Set left and right walls based on the section
            SetWallForRow(sectionIndex, y);
        }
    }

    void SetWallForRow(int sectionIndex, int y)
    {
        // Set far left tile at position 0
        Vector3Int leftTilePosition = new Vector3Int(0, y, 0);
        TileBase leftTile = GetRandomLeftTile(sectionIndex);
        tilemap.SetTile(leftTilePosition, leftTile);

        // Set right wall tile at the specified position
        Vector3Int rightTilePosition = new Vector3Int(24, y, 0); // Assuming the right wall is at position 49
        TileBase rightTile = GetRandomRightTile(sectionIndex);
        tilemap.SetTile(rightTilePosition, rightTile);
    }

    TileBase GetRandomLeftTile(int sectionIndex)
    {
        TileBase[] leftTiles;
        switch (sectionIndex)
        {
            case 0:
                leftTiles = leftTilesSection1;
                break;
            case 1:
                leftTiles = leftTilesSection2;
                break;
            case 2:
            default:
                leftTiles = leftTilesSection3;
                break;
        }

        int randomIndex = Random.Range(0, leftTiles.Length);
        return leftTiles[randomIndex];
    }

    TileBase GetRandomRightTile(int sectionIndex)
    {
        TileBase[] rightTiles;
        switch (sectionIndex)
        {
            case 0:
                rightTiles = rightTilesSection1;
                break;
            case 1:
                rightTiles = rightTilesSection2;
                break;
            case 2:
            default:
                rightTiles = rightTilesSection3;
                break;
        }

        int randomIndex = Random.Range(0, rightTiles.Length);
        return rightTiles[randomIndex];
    }
}
