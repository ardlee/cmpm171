using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections;
using System.Collections.Generic;

public class DisappearingPlatform : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase emptyTile; // An empty tile to represent disappearance
    public float disappearTime = 2f;
    public float appearTime = 2f;

    private List<Vector3Int> tilePositions = new List<Vector3Int>();
    private List<TileBase> originalTiles = new List<TileBase>();

    void Start()
    {
        // Store original tiles
        StoreOriginalTiles();

        // Start the disappearing/reappearing process
        StartCoroutine(DisappearAndReappear());
    }

    IEnumerator DisappearAndReappear()
    {
        while (true)
        {
            // Disappear
            yield return new WaitForSeconds(disappearTime);
            SetTiles(emptyTile);

            // Reappear
            yield return new WaitForSeconds(appearTime);
            RestoreTiles();
        }
    }

    void StoreOriginalTiles()
    {
        foreach (var pos in tilemap.cellBounds.allPositionsWithin)
        {
            if (tilemap.HasTile(pos))
            {
                tilePositions.Add(pos);
                originalTiles.Add(tilemap.GetTile(pos));
            }
        }
    }

    void SetTiles(TileBase tile)
    {
        foreach (var pos in tilePositions)
        {
            tilemap.SetTile(pos, tile);
        }
    }

    void RestoreTiles()
    {
        for (int i = 0; i < tilePositions.Count; i++)
        {
            tilemap.SetTile(tilePositions[i], originalTiles[i]);
        }
    }
}
