using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMovement : MonoBehaviour {
	public float m_speed = 15f;
	public float m_turn_speed = 90f;
	public float m_life_time = 2f;
	public float m_explosion_radius = 10f;
	public string Enemy_Tag = "Enemy";
	public GameObject m_Hit_Effect;
	public Vector3 default_position;

	private bool is_ready;
	private float time_left;
	private float m_range;
	private Transform m_target;
	void Start()
	{
		default_position = transform.position;
		is_ready = true;
		time_left = m_life_time;
		m_target = transform;
	}

	void Update ()
	{
		if (!gameObject.activeSelf)
			return;
		if (time_left < 0f) {
			Explode ();
			return;
		}
		if (GetComponent<Rigidbody> ().velocity != Vector3.zero)
			time_left -= Time.deltaTime;

		//aim and shoot
		Vector3 dir = m_target.position - transform.position;
		transform.Translate (dir.normalized * m_speed * Time.deltaTime, Space.World);
		transform.LookAt (m_target);
	}

	public void SetPosition (Vector3 _pos)
	{
		transform.position = _pos;
	}

	public void SetRotation (Quaternion _pos)
	{
		transform.rotation = _pos;
	}

	public void Fired(Transform _target)
	{
		m_target = _target;
		gameObject.SetActive (true);
		is_ready = false;
	}

	void OnTriggerEnter (Collider col)
	{
		if (col.CompareTag(Enemy_Tag)){
			//Create hit effect and distroy it after 2 seconds
			Destroy (Instantiate (m_Hit_Effect, col.transform.position, col.transform.rotation), 2f);
			//TODO: create damage per shot
			//TEMP: one shot one kill
			Explode();
		}
	}

	void Explode()
	{
		Collider[] colliders = Physics.OverlapSphere (transform.position, m_explosion_radius);
		foreach (Collider collider  in colliders)
			if (collider.CompareTag (Enemy_Tag))
				Damage (collider.gameObject);
		Reset ();
	}

	void Damage(GameObject _enemy)
	{
		//TODO: add Damage mearsue
		Destroy (_enemy.gameObject);
	}

	void Reset()
	{
		is_ready = true;
		time_left = m_life_time;
		gameObject.SetActive (false);
	}

	bool isReady()
	{return is_ready;}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, m_explosion_radius);
	}
}