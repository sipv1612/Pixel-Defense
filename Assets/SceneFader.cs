using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour {

	public Image fade_image;
	public Color fade_color = Color.black;
	public float fade_time = 1f;
	public AnimationCurve fade_curve;

	void Start()
	{
		StartCoroutine ("FadeIn");
	}

	IEnumerator FadeIn()
	{
		float time = 0f;

		while (time < fade_time) {
			time += Time.deltaTime;
			fade_image.color = new Color(fade_color.r, fade_color.g, fade_color.b, 1 - fade_curve.Evaluate(time));
			yield return 0f;
		}
	}

	public void LoadScene (string _scene)
	{
		StartCoroutine ("FadeTo", _scene);
	}

	IEnumerator FadeTo(string _scene)
	{
		float time = 0f;

		while (time < fade_time) {
			time += Time.deltaTime;
			fade_image.color = new Color(fade_color.r, fade_color.g, fade_color.b, fade_curve.Evaluate(time));
			yield return 0f;
		}

		SceneManager.LoadScene (_scene);
	}

	public void ExitGame()
	{
		Application.Quit ();
	}

}
