using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public event EventHandler OnLivesChanged;
    [SerializeField] private WorldLogic worldLogic;
    [SerializeField] private BallLogic ballLogic;
    public GameObject Modal;

    public int Points { get; set; } // Points per level
    public int Lives { get; set; }
    public int Score { get; set; } // Total score
    public  int Difficulty { get; set; }
    public float LevelStartTime { get; set; }
    public float LevelEndTime { get; set; }
    public int ElapsedTime { get; set; }

    private void Awake()
    {
        // Ensure there's only one instance of this class in the game
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Prevents the object from being destroyed when loading a new scene
        }
        else
        {
            Destroy(gameObject); // Destroy this if another instance already exists
        }
    }

    public void InitializeGameState()
    {
        Points = 0; // Reset points
        Lives = 3; // Set starting lives to 3
        Score = 0; // Reset score
        Difficulty = 2; // Set starting difficulty to 1
    }
    public void AddPoints(int pointsToAdd)
    {
        Points += pointsToAdd;
    }

    public void LoseLife()
    {
        Lives--;
        OnLivesChanged?.Invoke(this, EventArgs.Empty); // Notify subscribers that Lives has changed
    }

    public void GetTotal()
    {
        Score += Points;
    }

    public bool AreAllTilesCleared()
    {
        GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tile");
        return tiles.Length == 0; // Returns true when no more tiles
    }
    public void CheckLevelCompletion()
    {
        StartCoroutine(CheckLevelCompletionAfterDelay());
    }

    public void CalculateTimeBasedBonus()
    {
        int baseMaxTimeBonus = 1000; // Base maximum bonus points available
        int baseTimeThreshold = 20; // Base time in seconds for the maximum bonus
        int minimumBonus = 100; // Minimum bonus points

        // Scale the maxTimeBonus and timeThreshold with the Difficulty level
        int maxTimeBonus = baseMaxTimeBonus + (Difficulty * 100); // Increase max bonus by 100 per difficulty level
        int timeThreshold = baseTimeThreshold + (Difficulty * 2); // Increase time threshold by 2 seconds per difficulty level

        // Calculate the bonus for the level based on elapsed time
        int timeBonus = Mathf.Max(minimumBonus, maxTimeBonus - (ElapsedTime * (maxTimeBonus - minimumBonus) / timeThreshold));

        // Add the time-based bonus to the score
        Points += timeBonus;

        Debug.Log($"Time Bonus: {timeBonus}, Total Score: {Points}");
    }

    private IEnumerator CheckLevelCompletionAfterDelay()
    {
        yield return new WaitForEndOfFrame(); // Wait until the end of the frame

        if (AreAllTilesCleared())
        {
            LevelEndTime = Time.time;
            ElapsedTime = Mathf.RoundToInt(LevelEndTime - LevelStartTime);
            Debug.Log("Level Cleared!");
            Difficulty++;
            ballLogic.ResetBall();
            CalculateTimeBasedBonus();
            GetTotal();
            Modal.SetActive(true);
            worldLogic.GenerateLevel(worldLogic.rows, worldLogic.cols, Difficulty);
        }
    }
}