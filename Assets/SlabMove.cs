using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlabMove : MonoBehaviour
{
    public GameObject ball;
    private int counter = 0;   

    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, 100, 10));
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
            ball.GetComponent<Rigidbody2D>().velocity *= 1.1f;
            counter = 0;
        }
    }
}
