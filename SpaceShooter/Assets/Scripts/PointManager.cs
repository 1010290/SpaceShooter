using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour
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
