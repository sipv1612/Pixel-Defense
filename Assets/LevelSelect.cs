using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour {

	public void OpenScene(string _scene_Name)
	{
		SceneManager.LoadScene (_scene_Name);
	}
	public void OpenScene(int _scene_Index)
	{
		SceneManager.LoadScene (_scene_Index);
	}
}
