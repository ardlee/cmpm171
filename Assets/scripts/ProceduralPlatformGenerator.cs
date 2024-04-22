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

    public int minSeparationHorizontal = 3;
    public int maxSeparationHorizontal = 7;
    public int minSeparationVertical = 3;
    public int maxSeparationVertical = 7;

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

        // Generate additional platforms throughout the map
        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                // Check if this position is suitable for a platform and not on the base platform
                if (IsPlatformPosition(x, y) && !IsOnBasePlatform(x, y))
                {
                    // Generate platform at this position
                    GeneratePlatform(x, y);
                }
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

    void GeneratePlatform(int startX, int startY)
    {
        for (int x = startX; x < startX + platformWidth; x++)
        {
            Vector3Int tilePosition = new Vector3Int(x, startY, 0);
            tilemap.SetTile(tilePosition, platformTile);
        }
    }

    bool IsPlatformPosition(int x, int y)
    {
        // Check if the position is within the map bounds
        if (x + platformWidth > mapWidth || y + 1 > mapHeight)
        {
            return false;
        }

        // Check horizontal and vertical separations
        int horizontalSeparation = Random.Range(minSeparationHorizontal, maxSeparationHorizontal + 1);
        int verticalSeparation = Random.Range(minSeparationVertical, maxSeparationVertical + 1);

        return (x % horizontalSeparation == 0) && (y % verticalSeparation == 0);
    }

    bool IsOnBasePlatform(int x, int y)
    {
        // Check if the position is on the base platform
        return y == 0 && x >= 0 && x < mapWidth;
    }
}
