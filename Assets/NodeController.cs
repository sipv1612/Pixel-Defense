using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeController : MonoBehaviour {
	public Color m_highlight_color;
	public Vector3 turret_offset;

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
		m_render.material.color = m_highlight_color;
	}

	void OnMouseDown()
	{
		if (m_turret != null) {
			Debug.Log ("Turret exist already!");
			return;
		}
		m_turret = (GameObject)Instantiate (BuildManager.instance.getTurretToBuild (), transform.position + turret_offset, transform.rotation);
	}

	void OnMouseExit()
	{
		m_render.material.color = m_default_color;
	}
}
