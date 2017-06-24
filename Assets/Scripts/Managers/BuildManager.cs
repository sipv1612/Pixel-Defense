using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour {

	public static BuildManager instance;
	public GameObject[] turret_prefabs;
	public Button cancel_select_button;
	public int player_money = 500;
	public Text player_money_text;

	private GameObject turret_to_build;
	void Awake()
	{
		if (instance == null)
			instance = this;
		else
			Debug.LogError ("There are more than one BuildManager!");
		cancel_select_button.interactable = false;
		player_money_text.text = player_money.ToString () + "$";
	}

	public GameObject getTurretToBuild()
	{
		return turret_to_build;
	}

	public bool setTurretToBuild(GameObject _turret)
	{
		//Cancel select turret to build
		if (_turret == null) {
			turret_to_build = null;
			cancel_select_button.interactable = false;
			return true;
		}
		//change turret_to_build if _turret exist in prefabs
		cancel_select_button.interactable = true;
		foreach (GameObject turret in turret_prefabs) {
			if (turret == _turret) {
				turret_to_build = _turret;
				return true;
			}
		}
		return false;
	}

	public bool UseMoney(int _money)
	{
		if (_money > player_money) {
			Debug.Log ("Not enough money!");
			return false;
		}
		player_money -= _money;
		player_money_text.text = player_money.ToString () + "$";
		return true;
	}

}
