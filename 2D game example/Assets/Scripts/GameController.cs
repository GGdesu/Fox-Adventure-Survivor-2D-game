using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public int totalScore;

    private int bestScore;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText;
    public GameObject gameOver;

    public static GameController instance;

    void Start()
    {
        instance = this;

        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        UpdateBestScoreText();
    }

    void Update()
    {
        if (totalScore > bestScore)
        {
            bestScore = totalScore;
            UpdateBestScoreText();
        }
    }

    public void NewGame()
    {
        SceneManager.LoadScene("UniqueStage");
    }

    public void UpdateScoreText()
    {
        scoreText.text = totalScore.ToString();
    }

    public void UpdateBestScoreText()
    {

        bestScoreText.text = bestScore.ToString();
    }

    public void ShowGameOver()
    {
        gameOver.SetActive(true);
    }

    public void RestartGame(string lvl_name)
    {
        PlayerPrefs.SetInt("BestScore", bestScore);
        SceneManager.LoadScene(lvl_name);
    }

    
}
