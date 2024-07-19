using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private ParticleSystem lightningParticleSystem;

    // Start is called before the first frame update
    void Start()
    {
        GameObject lightningObject = GameObject.Find("Lightning");
        lightningParticleSystem = lightningObject.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        lightningParticleSystem.Play();
        Destroy(gameObject);
    }
}
