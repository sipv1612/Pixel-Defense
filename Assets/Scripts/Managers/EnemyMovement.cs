using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public float m_speed;

	private Transform[] m_Waypoints;
	private int m_cur_Waypoint_Index;
	private Transform m_transform;

	void Start()
	{
		m_Waypoints = Waypoints.points;
		m_transform = GetComponent<Transform>();
		m_cur_Waypoint_Index = 0;
	}

	void Update()
	{
		Move ();

	}

	void Move()
	{
		if (Vector3.Distance (m_Waypoints [m_cur_Waypoint_Index].position, m_transform.position) < 0.5f) {
			m_cur_Waypoint_Index++;
			if (m_cur_Waypoint_Index >= m_Waypoints.Length)
				m_cur_Waypoint_Index--;
		}
		Vector3 dir = Vector3.zero; //direction vector
		dir = m_Waypoints[m_cur_Waypoint_Index].position - m_transform.position;
		dir.Normalize();
		m_transform.Translate(dir * m_speed * Time.deltaTime);
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag ("End")) {
			//TO DO: Counting Points here
			Debug.Log (gameObject.name + " Destroyed!");
			Destroy (gameObject);
		}
	}
}
