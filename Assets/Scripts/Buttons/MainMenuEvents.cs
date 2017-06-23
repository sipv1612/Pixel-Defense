using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuEvents : MonoBehaviour {
	public Sprite volume_on;
	public Sprite volume_off;
	public GameObject volume_button;

	private float start_volume;
	private Button m_button;

	void Start()
	{
		m_button = volume_button.GetComponent<Button> ();
		start_volume = AudioListener.volume;
		if (start_volume == 0)
			m_button.image.sprite = volume_off;
		else
			m_button.image.sprite = volume_on;
	}

	public void VolumePressed()
	{
		//volume off
		if (AudioListener.volume > 0) {
			m_button.image.sprite = volume_off;
			AudioListener.volume = 0;
			Debug.Log ("Volume off: " + AudioListener.volume);
			return;
		}
		//volume on
		m_button.image.sprite = volume_on;
		AudioListener.volume = start_volume;
		Debug.Log ("Volume on: " + AudioListener.volume);
	}

	public void PlayPressed()
	{
		Debug.LogError ("Lets edit button navigation in MainMenuEvents.cs!");
	}

	public void QuitPressed()
	{
		Debug.LogWarning ("You're about to exit the game! (Apllication.Quit())");
		Application.Quit ();
	}
}
