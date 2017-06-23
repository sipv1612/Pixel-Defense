using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameOverEvents : MonoBehaviour {
	public Text Score_Text;

	public void setScore(int _score)
	{
		if (_score >= 0)
			Score_Text.text = _score.ToString();
		else
			Debug.LogError ("Score pass to GameOverEvents is less than 0");
	}

	public void RetryPressed()
	{
		Debug.LogError("Lets complete RetryPressed funtion!");
	}

	public void MenuPressed()
	{
		SceneManager.LoadScene ("MainMenu", LoadSceneMode.Single);
	}
}
