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

        // base 5 to avoid generating on the base platform
        int y = 5; 

        while (y < mapHeight)
        {
            // platdform encounterer per row. For example 1-2 platforms per row (range)
            int platformsInThisRow = UnityEngine.Random.Range(1, 3); 
            List<int> usedPositions = new List<int>();

            for (int i = 0; i < platformsInThisRow; i++)
            {
                int x = UnityEngine.Random.Range(0, mapWidth - platformWidth);

                // if position is close to others in a row
                if (usedPositions.Any(pos => Mathf.Abs(pos - x) < minSeparationHorizontal))
                {
                    continue;
                }

                GeneratePlatform(x, y);
                usedPositions.Add(x);
            }

            // create separation based on player's jump
            y += UnityEngine.Random.Range(minSeparationVertical, maxSeparationVertical + 1);
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
