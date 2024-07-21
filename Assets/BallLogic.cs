using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class BallLogic : MonoBehaviour
{
    public GameObject lightning;
    private ParticleSystem lightningParticleSystem;
    public float newAngleDegrees = 90f; // new angle for the angle breaker
    private Rigidbody2D rb;
    public GameObject LevelClearedScreen;
    public AudioSource bounceSound;
    public AudioSource lightningSound;

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
                GameManager.Instance.GetTotal();
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
        double startTime = AudioSettings.dspTime + 0.0005;
        bounceSound.PlayScheduled(startTime);
        if (rb.velocity.y > 0f && rb.velocity.y < 0.8f)
        {
            float newAngleRadians = newAngleDegrees * Mathf.Deg2Rad; // Convert degrees to radians
            Vector2 newVelocity = new Vector2(Mathf.Cos(newAngleRadians), Mathf.Sin(newAngleRadians)) * rb.velocity.magnitude;

            // Set the Rigidbody's velocity
            rb.velocity = newVelocity;
            Debug.Log("Angle Breaker!");
        } else if (rb.velocity.y < 0f && rb.velocity.y > -0.8f)
        {
            float newAngleRadians = newAngleDegrees * Mathf.Deg2Rad; // Convert degrees to radians
            Vector2 newVelocity = new Vector2(Mathf.Cos(newAngleRadians), Mathf.Sin(newAngleRadians)) * rb.velocity.magnitude;

            // Set the Rigidbody's velocity
            rb.velocity = newVelocity;
            Debug.Log("Angle Breaker!");
        }

        if (collision.gameObject.CompareTag("Tile"))
        {
            float chance = 0.3f; // 30% chance.
            if (Random.value < chance)
            {
                Debug.Log("Lightning Strike!");
                lightningParticleSystem.Play();
                lightningSound.Play();
                Debug.Log("Attempting to play lightning sound");
            }
        }
    }
    public void ResetBall()
    {

        rb.velocity = Vector2.zero; // Reset velocity to 0
        transform.position = new Vector3(0, -2, 0); // Reset the ball's position
    }
}
