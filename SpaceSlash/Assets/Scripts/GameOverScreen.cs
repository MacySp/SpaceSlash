using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public bool isActive = false;
    public Text endgameScore;
    [SerializeField] private Text endgameHighscore;
    public int score;
    public int highscore;
    ScoreManager scoreManager;

    public void Awake()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    public void PrintScore()

    {

            score = scoreManager.score;
        highscore = scoreManager.highscore;
            gameObject.SetActive(true);
            endgameScore.text = "Your Score: " + score.ToString();
        endgameHighscore.text = "Your Highscore: " + highscore.ToString();

    }
    public void RestartGame()
    {
        SceneManager.LoadScene("MainGame");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
