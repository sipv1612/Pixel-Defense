using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

	public static BuildManager instance;
	public GameObject[] turret_prefabs;

	private GameObject turret_to_build;
	void Awake()
	{
		if (instance == null)
			instance = this;
		else
			Debug.LogError ("There are more than one BuildManager!");
	}

	public GameObject getTurretToBuild()
	{
		return turret_to_build;
	}

	public bool setTurretToBuild(GameObject _turret)
	{
		//change turret_to_build if _turret exist in prefabs
		foreach (GameObject turret in turret_prefabs) {
			if (turret == _turret) {
				turret_to_build = _turret;
				return true;
			}
		}
		return false;
	}
}
