using UnityEngine;
using UnityEngine.Tilemaps;

public class FlagSpawn : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase tile;

    private void Start()
    {
        SpawnTiles();
    }

    private void SpawnTiles()
    {
        int fixedY = 49;

        // Loop through x values from 1 to 24
        for (int x = 1; x < 24; x++)
        {
            Vector3Int spawnPosition = new Vector3Int(x, fixedY, 0);
            tilemap.SetTile(spawnPosition, tile);
        }
    }
}
