using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ProceduralPlatformGenerator : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase basePlatformTile;
    public TileBase platformTile;

    public int mapWidth = 50;
    public int mapHeight = 10;
    public int platformWidth = 3;

    public int minSeparationHorizontal = 6;
    public int maxSeparationHorizontal = 14; 
    public int minSeparationVertical = 2;
    public int maxSeparationVertical = 4;

    void Start()
    {
        GeneratePlatforms();
    }
    
    void GeneratePlatforms()
{
    // Ensure the Tilemap is not null
    if (tilemap == null)
    {
        Debug.LogError("Tilemap is not assigned!");
        return;
    }

    // Generate base platform at height 0
    GenerateBasePlatform();

    int y = 3; // Start at a specific height

    while (y < mapHeight)
    {
        // Reduce the range of platforms per row
        int platformsInThisRow = UnityEngine.Random.Range(1, 3); 
        List<int> usedPositions = new List<int>();

        for (int i = 0; i < platformsInThisRow; i++)
        {
            int x = UnityEngine.Random.Range(0, mapWidth - platformWidth);

            // Check if position is close to others in a row
            if (usedPositions.Any(pos => Mathf.Abs(pos - x) < minSeparationHorizontal))
            {
                continue;
            }

            GeneratePlatform(x, y);
            usedPositions.Add(x);

            // Add additional spacing after each platform
            x += UnityEngine.Random.Range(minSeparationHorizontal, maxSeparationHorizontal + 1);
        }

        // Reduce the vertical separation range for more frequent platforms
        y += UnityEngine.Random.Range(minSeparationVertical, maxSeparationVertical - 1);
    }
}



    void GenerateBasePlatform()
    {
        for (int x = 0; x < mapWidth; x++)
        {
            Vector3Int tilePosition = new Vector3Int(x, 0, 0);
            tilemap.SetTile(tilePosition, basePlatformTile);
        }
    }

    void GeneratePlatform(int startX, int startY)
    {
        for (int x = startX; x < startX + platformWidth; x++)
        {
            Vector3Int tilePosition = new Vector3Int(x, startY, 0);
            tilemap.SetTile(tilePosition, platformTile);
        }
    }
}
