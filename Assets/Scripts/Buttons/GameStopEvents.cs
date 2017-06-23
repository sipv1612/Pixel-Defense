using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStopEvents : MonoBehaviour {
	public SceneFader fader;
	public Text m_score;
	public GameObject pause_menu;

	public void setScore(int _score)
	{
		if (_score >= 0)
			m_score.text = _score.ToString ();
		else
			Debug.LogError ("Score pass to GameOverEvents is less than 0");
	}

	public void RetryPressed()
	{
		fader.LoadScene (SceneManager.GetActiveScene().name);
	}

	public void MenuPressed()
	{
		fader.LoadScene ("MainMenu");
	}

	public void ResumePressed()
	{
		pause_menu.SetActive (false);
	}

	public void PausePressed()
	{
		pause_menu.SetActive (true);
	}
}
