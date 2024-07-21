using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TileCollision : MonoBehaviour
{
    //private ParticleSystem lightningParticleSystem;
    private Color tileColor;
    // Start is called before the first frame update
    void Start()
    {
        tileColor = GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CheckAndDestroyAdjacentTiles(gameObject, tileColor);
        GameManager.Instance.CheckLevelCompletion();
    }

    private void OnParticleCollision(GameObject other)
    {
        CheckAndDestroyAdjacentTiles(gameObject, tileColor);
        GameManager.Instance.CheckLevelCompletion();
    }

    void CheckAndDestroyAdjacentTiles(GameObject tileObject, Color colorToMatch)
    {
        // Immediately return if the tileObject is null or its collider is already disabled (indicating it's been processed)
        if (tileObject == null || !tileObject.GetComponent<Collider2D>().enabled)
        {
            return;
        }

        // Disable the collider to mark this tile as processed
        tileObject.GetComponent<Collider2D>().enabled = false;

        // Destroy the tileObject
        GameManager.Instance.AddPoints(1);
        Destroy(tileObject.transform.parent.gameObject);

        Vector2 horizontalBoxSize = new Vector2(2.1f, 0.1f); // Larger horizontally
        Vector2 verticalBoxSize = new Vector2(0.1f, 0.6f); // Larger vertically

        // Perform the checks for adjacent tiles in horizontal and vertical directions
        Collider2D[] horizontalAdjacentTiles = Physics2D.OverlapBoxAll(tileObject.transform.position, horizontalBoxSize, 0f, LayerMask.GetMask("Tile"));
        Collider2D[] verticalAdjacentTiles = Physics2D.OverlapBoxAll(tileObject.transform.position, verticalBoxSize, 0f, LayerMask.GetMask("Tile"));

        // Process all adjacent tiles
        foreach (var collider in horizontalAdjacentTiles)
        {
            GameObject adjacentTile = collider.gameObject;
            if (adjacentTile != null && adjacentTile.GetComponent<SpriteRenderer>().color == colorToMatch)
            {
                CheckAndDestroyAdjacentTiles(adjacentTile, colorToMatch); // Recursive call
            }
        }

        foreach (var collider in verticalAdjacentTiles)
        {
            GameObject adjacentTile = collider.gameObject;
            if (adjacentTile != null && adjacentTile.GetComponent<SpriteRenderer>().color == colorToMatch)
            {
                CheckAndDestroyAdjacentTiles(adjacentTile, colorToMatch); // Recursive call
            }
        }
    }
}
