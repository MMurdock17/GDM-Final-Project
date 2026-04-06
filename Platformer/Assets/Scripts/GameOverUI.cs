using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverUI : MonoBehaviour
{

    public TextMeshProUGUI finalScoreText;
    public TMP_InputField playerNameInput;

    void Start()
    {
        int finalScore = GameManager.Instance.GetScore();
        finalScoreText.text = "Final Score: " + finalScore;
    }

    public void TryAgain()
    {
        GameManager.Instance.ResetGame();
        SceneManager.LoadScene("GameScene");

        string playerName = playerNameInput.text;

        if (string.IsNullOrEmpty(playerName))
        {
            playerName = "Anonymous";
        }

        int finalScore = GameManager.Instance.GetScore();
        float completionTime = Time.timeSinceLevelLoad;

        DatabaseManager.Instance.SaveHighScore(playerName, finalScore, completionTime);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
