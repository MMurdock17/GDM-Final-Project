using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverUI : MonoBehaviour
{

    public TextMeshProUGUI finalScoreText;

    void Start()
    {
        int finalScore = GameManager.Instance.GetScore();
        finalScoreText.text = "Final Score: " + finalScore;
    }

    public void TryAgain()
    {
        GameManager.Instance.ResetGame();
        SceneManager.LoadScene("GameScene");
    }
}
