using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayScore : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI scoreText;

    void Start()
    {
        if (GameManager.Instance != null)
        {
            scoreText.text = "Score: " + GameManager.Instance.Score.ToString();
        }
    }
}
