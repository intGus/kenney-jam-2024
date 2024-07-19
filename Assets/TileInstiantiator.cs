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
    public GameObject inst;
    public GameObject ball;
    //private float timer = 10f;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Screen Width : " + Screen.width);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, Camera.main.nearClipPlane));
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
                m_SpriteRenderer[0].color = new Color(((float)Mathf.Abs(i) / 10), 0, 0, 1);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
