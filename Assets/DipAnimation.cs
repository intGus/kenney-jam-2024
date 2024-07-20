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
        StartCoroutine(SplashDelay());
    }

    // Update is called once per frame
    void Update()
    {
        //crossfadeGroup.alpha -= Time.deltaTime*1.5f; 
    }

    private IEnumerator SplashDelay()
    {
        
        yield return new WaitForSeconds(2);

        float elapsedTime = 0f;
        float fadeDuration = 0.5f;

        while (elapsedTime < fadeDuration)
        {
            // Calculate the new alpha value
            crossfadeGroup.alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);

            // Increment the elapsed time by the time since the last frame
            elapsedTime += Time.deltaTime;

            yield return null;
        }
        crossfadeGroup.alpha = 0;
    }
}
