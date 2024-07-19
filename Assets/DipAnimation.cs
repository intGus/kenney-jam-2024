using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DipAnimation : MonoBehaviour
{
    public CanvasGroup crossfadeGroup;
    // Start is called before the first frame update
    void Start()
    {
        crossfadeGroup.alpha = 1;
    }

    // Update is called once per frame
    void Update()
    {
        crossfadeGroup.alpha -= Time.deltaTime*1.5f; 
    }
}
