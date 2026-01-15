using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
	public TMP_Text pointsText;
	public void Setup(int score)
	{
		gameObject.SetActive(true);
		pointsText.text = "Score: " + score;
	}

	public void RestartButton()
	{
		SceneManager.LoadScene("GameScene");
	}

	public void ExitButton()
	{
        SceneManager.LoadScene("MainMenuScene");
    }
}
