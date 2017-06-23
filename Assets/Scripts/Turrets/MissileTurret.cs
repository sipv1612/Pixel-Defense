﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileTurret : MonoBehaviour {
	public float m_turn_Speed = 10f;
	public float m_fire_Rate = 0.5f;
	public float m_range = 25f;
	public Transform m_turret;
	public string enemy_Tag = "Enemy";
	public GameObject Missile_Prefab;

	private Transform m_target;
	private float m_fire_Countdown;

	//tesing purpose

	void Start()
	{
		m_target = null;
		m_fire_Countdown = 0;
		InvokeRepeating ("ScanEnemy", 0f, 0.25f);

	}

	void Update()
	{
		if (m_target != null) {
			Aim ();
			if (m_fire_Countdown <= 0) {
				Shoot ();
				m_fire_Countdown = 1f / m_fire_Rate;
			}
			m_fire_Countdown -= Time.deltaTime;
		}
	}

	void ScanEnemy()
	{
		//enemy out range
		if (m_target != null && Vector3.Distance (transform.position, m_target.position) > m_range) {
			m_target = null;
		}
		//choose an enemy to aim
		if (m_target == null) {
			GameObject[] enemies = GameObject.FindGameObjectsWithTag (enemy_Tag);
			float shortest_distance = m_range;
			foreach (GameObject enemy in enemies) {
				float distance_to_enemy = Vector3.Distance (transform.position, enemy.transform.position);
				if (distance_to_enemy <= shortest_distance) {
					shortest_distance = distance_to_enemy;
					m_target = enemy.transform;
				}
			}
		}
	}

	void Aim()
	{
		Vector3 dir = m_target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation(dir);
		Vector3 rotation = Quaternion.Lerp(m_turret.rotation, lookRotation, Time.deltaTime * m_turn_Speed).eulerAngles;
		m_turret.rotation = Quaternion.Euler(0f, rotation.y, 0f);
	}

	void Shoot()
	{
		GameObject missile = (GameObject)Instantiate (Missile_Prefab, m_turret.transform.GetChild (0).position, m_turret.transform.GetChild (0).rotation);
		missile.GetComponent<MissileMovement> ().Fired (m_range);
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, m_range);
	}
}