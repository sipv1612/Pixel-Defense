using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour {
	public Sprite volume_on;
	public Sprite volume_off;

	private float start_volume;
	private Button m_button;

	void Start()
	{
		m_button = GetComponent<Button> ();
		start_volume = AudioListener.volume;
		if (start_volume == 0)
			m_button.image.sprite = volume_off;
		else
			m_button.image.sprite = volume_off;
	}

	public void TurnVolume()
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
}
