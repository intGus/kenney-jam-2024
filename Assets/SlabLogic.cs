using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlabMove : MonoBehaviour
{
    public GameObject ball;
    private int counter = 0;
    public float angleAdjustmentFactor = 50f;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
        rb = ball.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, 50, 0.3f));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3) 
        {
            counter += 1;
        }

        if (counter == 5)
        {
            Debug.Log("Speeding!");
            rb.velocity *= 1.1f;
            counter = 0;
        }
        GameManager.Instance.CheckLevelCompletion();
    }
}
