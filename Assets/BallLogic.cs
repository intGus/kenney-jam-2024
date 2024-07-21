using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class BallLogic : MonoBehaviour
{
    public GameObject lightning;
    private ParticleSystem lightningParticleSystem;
    public float newAngleDegrees = 90f; // The new angle you want to set, in degrees
    private Rigidbody2D rb;
    public GameObject LevelClearedScreen;

    public Vector2 initialVelocity  = new Vector2(0, -5);
   
    // Start is called before the first frame update
    void Start()
    {
        lightningParticleSystem = lightning.GetComponent<ParticleSystem>();
        rb = GetComponent<Rigidbody2D>();
        ResetBall();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -5f)
        {
            GameManager.Instance.LoseLife();
            if (GameManager.Instance.Lives == 0)
            {
                SceneManager.LoadScene("GameOver");
            }
            ResetBall();
        }

        if (Input.GetMouseButtonDown(0) && !LevelClearedScreen.activeInHierarchy && rb.velocity.magnitude == 0) // Check if the ball is stationary
        {
            GameManager.Instance.LevelStartTime = Time.time;
            rb.velocity = initialVelocity;
        }


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (rb.velocity.y > 0f && rb.velocity.y < 0.8f)
        {
            // Calculate the new velocity vector based on the desired angle
            float newAngleRadians = newAngleDegrees * Mathf.Deg2Rad; // Convert degrees to radians
            Vector2 newVelocity = new Vector2(Mathf.Cos(newAngleRadians), Mathf.Sin(newAngleRadians)) * rb.velocity.magnitude;

            // Set the Rigidbody's velocity to the new velocity
            rb.velocity = newVelocity;
            Debug.Log("Angle Breaker!");
        } else if (rb.velocity.y < 0f && rb.velocity.y > -0.8f)
        {
            // Calculate the new velocity vector based on the desired angle
            float newAngleRadians = newAngleDegrees * Mathf.Deg2Rad; // Convert degrees to radians
            Vector2 newVelocity = new Vector2(Mathf.Cos(newAngleRadians), Mathf.Sin(newAngleRadians)) * rb.velocity.magnitude;

            // Set the Rigidbody's velocity to the new velocity
            rb.velocity = newVelocity;
            Debug.Log("Angle Breaker!");
        }    
        lightningParticleSystem.Play();
    }
    public void ResetBall()
    {

        rb.velocity = Vector2.zero; // Reset velocity to 0
        transform.position = new Vector3(0, -2, 0); // Reset the ball's position
    }
}
