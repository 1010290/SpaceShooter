using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour, IDataPersistence
{
    public int score;
    public int highScore;

    //Reference to which text shows the score
    public TMP_Text scoreText;

    //PREFS
    public TMP_Text highestScoreText;
    
    //PREFS END

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0;
        scoreText.text  = "Score: " + score;
        highestScoreText.text = "Highest: " + PlayerPrefs.GetInt("HighestScore", 0).ToString();
    }

    void Update()
    {
        UpdateHighScore();
    }

    public void LoadData(GameData data)
    {
        this.highScore = data.highScore;
    }

    public void SaveData(ref GameData data)
    {
        data.highScore = this.score;
    }

    public void UpdateScore(int points)
    {
        if (score <= 9980)
        {
            score += points;
            scoreText.text  = "Score: " + score;
        }
        if (score > 9980)
        {
            scoreText.text  = "Score: MAX";
        }
    }

    public void UpdateHighScore()
    {
        //int highestScore = 0;

        if(score > PlayerPrefs.GetInt("HighestScore", 0))
        {
            Debug.Log("Score is " + score);
            Debug.Log("HighScore is " + PlayerPrefs.GetInt("HighestScore", 0));
            Debug.Log("Changed Score");
            PlayerPrefs.SetInt("HighestScore", score);
            highestScoreText.text = "Highest: " + score.ToString();
        } else
        {
            Debug.Log("Didn't Change Score");
        }
    }
}
