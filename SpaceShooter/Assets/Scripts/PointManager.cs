using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour, IDataPersistence
{
    public int score;
    //Reference to which text shows the score
    public TMP_Text scoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0;
        scoreText.text  = "Score: " + score;
    }

    public void LoadData(GameData data)
    {
        this.score = data.highScore;
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
}
