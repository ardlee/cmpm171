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

    // Store the position of the final platform
    private Vector3Int finalPlatformPosition;

    void Start()
    {
        GeneratePlatforms();
        SpawnPlatformAtHeight(52); // Spawn platform at y = 52
        SpawnFinalPlatform();
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

    void SpawnPlatformAtHeight(int height)
    {
        // Ensure the height is within the bounds of the map
        if (height >= mapHeight)
        {
            Debug.LogError("Height is out of bounds!");
            return;
        }

        // Calculate a random starting x position ensuring the platform fits within the map width
        int startX = Random.Range(0, mapWidth - platformWidth);

        // Generate the platform
        GeneratePlatform(startX, height);
    }

    void SpawnFinalPlatform()
    {
        int y = 96; // Set the height to 48

        // Calculate a random starting x position between 1 and 22 (inclusive)
        int startX = Random.Range(1, 23); // Range is inclusive of min and exclusive of max, so use 23 to include 22

        // Ensure the platform fits within the map width
        if (startX + platformWidth > mapWidth)
        {
            startX = mapWidth - platformWidth; // Adjust startX to ensure the platform fits
        }

        // Generate the platform and store the middle position
        GeneratePlatform(startX, y);
        finalPlatformPosition = new Vector3Int(startX + platformWidth / 2, y, 0);
    }

    // Expose the final platform position
    public Vector3Int GetFinalPlatformPosition()
    {
        return finalPlatformPosition;
    }
}
