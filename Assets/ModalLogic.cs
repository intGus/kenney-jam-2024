using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ModalLogic : MonoBehaviour
{
    public GameObject modal;
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnEnable()
    {
        pointsText.text = "Points: " + GameManager.Instance.Points;
        timeText.text = "Time: " + GameManager.Instance.ElapsedTime + " seconds";
        scoreText.text = "Total Score: " + GameManager.Instance.Score;
        
    }

    public void CloseModal()
    {
        GameManager.Instance.Points = 0;
        modal.SetActive(false);
    }
}
