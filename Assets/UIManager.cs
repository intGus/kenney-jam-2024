using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI livesText;

    private void OnEnable()
    {
        GameManager.Instance.OnLivesChanged += UpdateLivesDisplay; // Subscribe to the event
    }

    private void OnDisable()
    {
        GameManager.Instance.OnLivesChanged -= UpdateLivesDisplay; // Unsubscribe from the event
    }

    private void UpdateLivesDisplay(object sender, System.EventArgs e)
    {
        livesText.text = "Lives: " + GameManager.Instance.Lives;
    }
}
