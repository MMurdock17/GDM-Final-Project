using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance { get; private set; }

    public event Action<int> onScoreChanged;
    public event Action<int> onHealthChanged;
    public event Action onGameOver;

    public int score = 0;
    public int health = 100;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("Score: " + score);

        onScoreChanged?.Invoke(score);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Health: " + health);

        onHealthChanged?.Invoke(health);

        if (health <= 0)
        {
            onGameOver?.Invoke();
        }
    }

    public void ResetGame()
    {
        score = 0;
        health = 100;

        onScoreChanged?.Invoke(score);
        onHealthChanged?.Invoke(health);
    }

    public void TriggerGameOver()
    {
        onGameOver?.Invoke();
    }

    public int GetScore()
    {
        return score;
    }

    public int GetHealth()
    {
        return health;
    }

}
