using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

	public static BuildManager instance;
	public GameObject turret_prefab;

	private GameObject turret_to_build;
	void Awake()
	{
		if (instance == null)
			instance = this;
		else
			Debug.LogError ("There are more than one BuildManager!");
	}

	void Start()
	{
		turret_to_build = turret_prefab;
	}

	public GameObject getTurretToBuild()
	{
		return turret_to_build;
	}
}
