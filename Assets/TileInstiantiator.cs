using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TileInstiantiator : MonoBehaviour
{
    SpriteRenderer[] m_SpriteRenderer;
    public GameObject tile;
    public Vector3 screenBounds;
    public int rows;
    public int cols;
    public float tileWidth = 2.0f;
    public float tileHeight = 0.5f;
    private GameObject inst;
    private GameObject ball;
    //private float timer = 10f;

    private Color[] colors = new Color[]
    {
        new Color(1, 0.30f, 0.37f, 1), // Red
        new Color(1, 1, 1, 1), // White
        new Color(0.25f, 0.62f, 0.86f, 1), // Blue
        new Color(1, 0.8f, 0, 1)  // Yellow
    };

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, Camera.main.nearClipPlane));
        Debug.Log("Screen Width : " + screenBounds.x);
        EdgeCollider2D edgeCollider = GetComponent<EdgeCollider2D>();
        Vector2[] edgePoints = new Vector2[4];
        edgePoints[0] = new Vector2(-screenBounds.x, -screenBounds.y);
        edgePoints[1] = new Vector2(-screenBounds.x, screenBounds.y);
        edgePoints[2] = new Vector2(screenBounds.x, screenBounds.y);
        edgePoints[3] = new Vector2(screenBounds.x, -screenBounds.y);
        edgeCollider.points = edgePoints;
        rows = (int)(Mathf.Round(screenBounds.x));
        cols = (int)Mathf.Abs(Mathf.Round(screenBounds.y));
        ball = GameObject.FindGameObjectWithTag("Ball");
        ball.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5);
        Debug.Log("Rows : " + rows + " Cols : " + cols);
        for (float i = rows; i < Mathf.Abs(rows); i+=tileWidth)
        {
            for (float j = 1; j <= cols; j+=tileHeight)
            {
                inst = Instantiate(tile, new Vector3(i+1, j-(tileHeight/2), 0), Quaternion.identity);
                m_SpriteRenderer = inst.GetComponentsInChildren<SpriteRenderer>();
                Color randomColor = colors[Random.Range(0, colors.Length)];
                m_SpriteRenderer[0].color = randomColor;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
