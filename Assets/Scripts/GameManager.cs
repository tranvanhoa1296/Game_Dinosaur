using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // UI Elements
    public GameObject mainMenu;
    public GameObject inGameUI;
    public GameObject gameOverScreen;
    public GameObject pauseScreen;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI lastScoreText;
    public TextMeshProUGUI highScoreText;

    private int score = 0;
    private int highScore = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    void Start()
    {
        ShowMainMenu();
        Time.timeScale = 0f;

        
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        int lastScore = PlayerPrefs.GetInt("LastScore", 0);

       
        UpdateScoreUI();
        lastScoreText.text = "Last: " + lastScore.ToString();


    }
    public void PlayerScored()
    {
        score += 1; 
        scoreText.text = "Score: " + score.ToString(); 

        
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore); 
            PlayerPrefs.Save(); 
            highScoreText.text = "Best: " + highScore.ToString(); 
        }
    }
    public void PlayGame()
    {
        mainMenu.SetActive(false);
        inGameUI.SetActive(true);
        score = 0; 
        UpdateScore(0); 
        Time.timeScale = 1f; 
    }

    public void PauseGame()
    {
        Time.timeScale = 0f; 
        pauseScreen.SetActive(true); 
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; 
        pauseScreen.SetActive(false); 
    }

    public void GameOver()
    {
        Time.timeScale = 0; 
        inGameUI.SetActive(false);
        gameOverScreen.SetActive(true); 

        PlayerPrefs.SetInt("LastScore", score); 
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
        PlayerPrefs.Save(); 
       
        UpdateScoreUI();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void ShowMainMenu()
    {
        mainMenu.SetActive(true);
        inGameUI.SetActive(false);
        gameOverScreen.SetActive(false);
        pauseScreen.SetActive(false);
    }

    public void UpdateScore(int addedScore)
    {
        score += addedScore;
        scoreText.text = "Score: " + score;
    }

    
    void UpdateScoreUI()
    {
        highScoreText.text = "Best: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        lastScoreText.text = "Last: " + PlayerPrefs.GetInt("LastScore", 0).ToString();
    }
  
}
