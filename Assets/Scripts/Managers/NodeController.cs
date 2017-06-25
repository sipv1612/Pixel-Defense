using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeController : MonoBehaviour {
	public Color m_highlight_color;

	private Color m_default_color;
	private Renderer m_render;
	private GameObject m_turret;
	void Start()
	{
		m_render = GetComponent<Renderer> ();
		m_default_color = m_render.material.color;
		m_turret = null;
	}

	void OnMouseEnter()
	{
		if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject ()) {
			OnMouseExit ();
			return;
		}
		m_render.material.color = m_highlight_color;
	}

	void OnMouseDown()
	{
		if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject ()) {
			OnMouseExit ();
			return;
		}
		if (m_turret != null) {
			Debug.Log ("Turret exist already!");
			return;
		}
		//build Turret
		if (BuildManager.instance.getTurretToBuild () != null) {
			
			//if player don't have enough money to build then do nothing and return
			if (!BuildManager.instance.UseMoney (BuildManager.instance.getTurretToBuild ().GetComponent<StandardTurret> ().GetCost ()))
				return;
			
			//else
			Vector3 turret_position = new Vector3(transform.position.x, BuildManager.instance.getTurretToBuild ().transform.position.y, transform.position.z);
			m_turret = (GameObject)Instantiate (BuildManager.instance.getTurretToBuild (), turret_position, transform.rotation);
			BuildManager.instance.setTurretToBuild (null);
		}
	}

	void OnMouseExit()
	{
		m_render.material.color = m_default_color;
	}
}
