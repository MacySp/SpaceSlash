using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    //public int scorePoints;

    [SerializeField] private Text scoreText;
    [SerializeField] private Text highscoreText;

    public int score = 0;
    public int highscore = 0;
    // Start is called before the first frame update

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = score.ToString();
        highscoreText.text = highscore.ToString();
    }

    public void AddPoint(int scorePoints)
    {
        if (score < highscore)
        {
            score = score + scorePoints;
            scoreText.text = score.ToString();
        }
        else if (score >= highscore)
        {
            score = score + scorePoints;
            highscore = score;
            scoreText.text = score.ToString();
            highscoreText.text = highscore.ToString();
            PlayerPrefs.SetInt("highscore", score);
        }
        /*score = score + scorePoints;
        scoreText.text = score.ToString();
        if (highscore < score)
            PlayerPrefs.SetInt("highscore", score);
            */
    }
    /*private void Update()
    {
;
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Reset Highscore");
            PlayerPrefs.SetInt("highscore", 0);
        }
    }*/
}
