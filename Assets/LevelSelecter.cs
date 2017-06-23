using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelecter : MonoBehaviour {
	public SceneFader fader;
	public Button[] level_buttons;
	public Sprite locked_image;

	private int level_reached;

	// Use this for initialization
	void Start () {
		level_reached = PlayerPrefs.GetInt ("level_reached", 1);

		for (int i = level_reached; i < level_buttons.Length; i++) {
			level_buttons [i].image.sprite = locked_image;
			level_buttons [i].GetComponentInChildren<Text> ().text = "";
			level_buttons [i].interactable = false;
		}
	}
	
	// Update is called once per frame
	void SelectLevel(string _level_name)
	{
		fader.LoadScene (_level_name);
	}
}
