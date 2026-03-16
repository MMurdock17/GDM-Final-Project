using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;

    void Start()
{
    scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
    healthText = GameObject.Find("HealthText").GetComponent<TextMeshProUGUI>();

    UpdateScore(GameManager.Instance.GetScore());
    UpdateHealth(GameManager.Instance.GetHealth());
}

    void OnEnable()
    {
        GameManager.Instance.onScoreChanged += UpdateScore;
        GameManager.Instance.onHealthChanged += UpdateHealth;
        GameManager.Instance.onGameOver += HandleGameOver;
    }

    void OnDisable()
    {
        GameManager.Instance.onScoreChanged -= UpdateScore;
        GameManager.Instance.onHealthChanged -= UpdateHealth;
        GameManager.Instance.onGameOver -= HandleGameOver;
    }

    void UpdateScore(int newScore)
    {
        scoreText.text = "Score: " + newScore;
        Debug.Log("Score updated successfully.");
    }

    void UpdateHealth(int newHealth)
    {
        healthText.text = "Health: " + newHealth;
        Debug.Log("Health updated successfully.");
    }

    void HandleGameOver()
    {
        SceneManager.LoadScene("GameOver");
        Debug.Log("Player died. Game over loading.");
    }

}
