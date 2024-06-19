using UnityEngine;
using UnityEngine.Tilemaps;

public class FlagSpawn : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase tile;
    public ProceduralPlatformGenerator platformGenerator; // Reference to the platform generator

    private void Start()
    {
        SpawnTile();
    }

    private void SpawnTile()
    {
        if (platformGenerator == null)
        {
            Debug.LogError("PlatformGenerator is not assigned!");
            return;
        }

        // Get the final platform position from the generator
        Vector3Int finalPlatformPosition = platformGenerator.GetFinalPlatformPosition() + new Vector3Int(0, 1, 0);

        // Set the flag tile at the final platform position
        tilemap.SetTile(finalPlatformPosition, tile);
    }
}
