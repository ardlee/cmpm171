using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ProceduralPlatformGenerator : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase basePlatformTile;
    public TileBase platformTile;

    public int mapWidth = 50;
    public int mapHeight = 40; // Changed to maximum platform level
    public int platformWidth = 3;

    public int minPlatformSpacingHorizontal = 3; // Adjusted to meet the requirements
    public int maxPlatformSpacingHorizontal = 5; // Adjusted to meet the requirements
    public int minSeparationVertical = 1; // Adjusted to meet the requirements
    public int maxSeparationVertical = 3; // Adjusted to meet the requirements

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
            int platformsGeneratedThisRow = 0; // Track the number of platforms generated for this y-level
            GeneratePlatformRow(y, ref platformsGeneratedThisRow);

            // Check if three platforms have been generated for this y-level
            if (platformsGeneratedThisRow == 3)
            {
                y += Random.Range(minSeparationVertical, maxSeparationVertical + 1);
            }
            else
            {
                GeneratePlatformRow(y + Random.Range(minSeparationVertical, maxSeparationVertical + 1), ref platformsGeneratedThisRow);
                y += Random.Range(minSeparationVertical, maxSeparationVertical + 1);
            }
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

    void GeneratePlatformRow(int y, ref int platformsGenerated)
    {
        int platformsPerRow = 3; // Change to generate three platforms per row

        int totalPlatformWidth = platformWidth * platformsPerRow;
        int totalSpacingWidth = Random.Range(minPlatformSpacingHorizontal, maxPlatformSpacingHorizontal + 1) * (platformsPerRow - 1);
        int availableWidth = mapWidth - totalPlatformWidth - totalSpacingWidth + 1;

        if (availableWidth <= 0) return; // Ensure enough space for platforms

        int startX = Random.Range(1, availableWidth); // Start from 1 to avoid x position 0

        for (int i = 0; i < platformsPerRow; i++)
        {
            GeneratePlatform(startX + i * (platformWidth + Random.Range(minPlatformSpacingHorizontal, maxPlatformSpacingHorizontal + 1)), y);
            platformsGenerated++;
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
