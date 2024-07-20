using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public event EventHandler OnLivesChanged;

    public int Points { get; set; }
    public int Lives { get; set; } // remove this for final version

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
}