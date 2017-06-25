using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

	public GameObject Standard_Turret_Prefab;
	public GameObject Missile_Laucher_Prefab;

	private BuildManager buildManager;

	void Start()
	{
		buildManager = BuildManager.instance;
	}

	public void CancelSelect()
	{
		if (buildManager.setTurretToBuild (null))
			Debug.Log ("Canceled Selection");
	}

	public void SelectStandardTurret()
	{
		if (buildManager.setTurretToBuild (Standard_Turret_Prefab))
			Debug.Log ("Standard turret selected");
	}

	public void SelectMissileLauncher()
	{
		if (buildManager.setTurretToBuild (Missile_Laucher_Prefab))
			Debug.Log ("Missile Launcher selected");
	}

}
