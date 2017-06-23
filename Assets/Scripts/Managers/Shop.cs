using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

	public GameObject Standard_Turret_Prefab;
	public GameObject Another_Turret_Prefab;

	private BuildManager buildManager;

	void Start()
	{
		buildManager = BuildManager.instance;
	}

	public void SelectStandardTurret()
	{
		if (buildManager.setTurretToBuild (Standard_Turret_Prefab))
			Debug.Log ("Standard turret selected");
	}

	public void SelectAnotherTurret()
	{
		if (buildManager.setTurretToBuild (Another_Turret_Prefab))
			Debug.Log ("Another turret selected");
	}

}
