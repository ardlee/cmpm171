using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase[] section1Tiles;
    public TileBase[] section2Tiles;
    public TileBase[] section3Tiles;

    public int mapWidth = 30;
    public int mapHeight = 10;

    public int numSections = 3;
    public int sectionHeight;

    void Start()
    {
        sectionHeight = mapHeight / numSections; // Calculate the height of each section
        GenerateMap();
    }

    void GenerateMap()
    {
        // Randomize the order of section tile arrays
        ShuffleTileArrays();

        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                Vector3Int tilePosition = new Vector3Int(x, y, 0);
                TileBase tile;

                // Determine which section this tile belongs to based on its y-coordinate
                int sectionIndex = y / sectionHeight;

                // Get a random tile based on the section index
                if (sectionIndex == 0)
                {
                    tile = GetRandomTileInSection(section1Tiles);
                }
                else if (sectionIndex == 1)
                {
                    tile = GetRandomTileInSection(section2Tiles);
                }
                else
                {
                    tile = GetRandomTileInSection(section3Tiles);
                }

                tilemap.SetTile(tilePosition, tile);
            }
        }
    }

    TileBase GetRandomTileInSection(TileBase[] sectionTiles)
    {
        int randomIndex = Random.Range(0, sectionTiles.Length);
        return sectionTiles[randomIndex];
    }

    void ShuffleTileArrays()
    {
        // Create a temporary array to hold the randomized order of section tiles
        TileBase[][] tempArrays = new TileBase[][] { section1Tiles, section2Tiles, section3Tiles };

        // Shuffle the order of arrays using Fisher-Yates shuffle algorithm
        for (int i = tempArrays.Length - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            TileBase[] temp = tempArrays[i];
            tempArrays[i] = tempArrays[randomIndex];
            tempArrays[randomIndex] = temp;
        }

        // Assign the shuffled arrays back to the original arrays
        section1Tiles = tempArrays[0];
        section2Tiles = tempArrays[1];
        section3Tiles = tempArrays[2];
    }
}
