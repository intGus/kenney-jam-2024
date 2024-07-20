using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BallLogic : MonoBehaviour
{
    public GameObject lightning;
    private ParticleSystem lightningParticleSystem;
    public float newAngleDegrees = 45f; // The new angle you want to set, in degrees
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        lightningParticleSystem = lightning.GetComponent<ParticleSystem>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -5f)
        {
            Debug.Log("Game Over!");
        }


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Mathf.Approximately(rb.velocity.y, 0f))
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
}
