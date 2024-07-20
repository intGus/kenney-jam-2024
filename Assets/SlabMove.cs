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
        //Vector2 paddlePosition = transform.position;
        //Vector2 hitPosition = collision.contacts[0].point;
        //float paddleWidth = GetComponent<Collider2D>().bounds.size.x;
        //float relativePosition = (hitPosition.x - paddlePosition.x) / (paddleWidth / 2);

        //Vector2 currentDirection = rb.velocity.normalized;
        //float speed = rb.velocity.magnitude;

        //float angleAdjustment = relativePosition * angleAdjustmentFactor; // Adjust this factor to control the sensitivity

        //// Adjust the ball's direction
        //float currentAngle = Mathf.Atan2(currentDirection.y, currentDirection.x) * Mathf.Rad2Deg;
        //float newAngle = currentAngle + angleAdjustment;
        //Vector2 newDirection = new Vector2(Mathf.Cos(newAngle * Mathf.Deg2Rad), Mathf.Sin(newAngle * Mathf.Deg2Rad));

        //// Apply the new velocity to the ball
        //rb.velocity = newDirection * speed;

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
    }
}
