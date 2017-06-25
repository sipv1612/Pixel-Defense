using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMovement : MonoBehaviour {
	public float m_speed = 15f;
	public string Enemy_Tag = "Enemy";
	public GameObject m_Hit_Effect;

	private Vector3 default_position;
	private bool is_ready;
	private float flied_Distance;
	private float m_range;
	void Start()
	{
		default_position = transform.position;
		is_ready = true;
		flied_Distance = 0f;
	}

	void Update ()
	{
		if (GetComponent<Rigidbody> ().velocity != Vector3.zero)
			flied_Distance += GetComponent<Rigidbody> ().velocity.magnitude * Time.deltaTime;
		if (flied_Distance >= m_range)
			Reset();
	}

	public void SetPosition (Vector3 _pos)
	{
		transform.position = _pos;
	}

	public void Fired(float _range)
	{
		gameObject.SetActive (true);
		GetComponent<Rigidbody>().velocity = transform.forward * m_speed;
		m_range = _range;
		is_ready = false;
	}

	void OnTriggerEnter (Collider col)
	{
		if (col.CompareTag(Enemy_Tag)){
			//Create hit effect and distroy it after 2 seconds
			Destroy (Instantiate (m_Hit_Effect, col.transform.position, col.transform.rotation), 2f);
			//TODO: create damage per shot
			//TEMP: one shot one kill
			Destroy(col.gameObject);
			Reset();
		}
	}

	void Reset()
	{
		transform.position = default_position;
		GetComponent<Rigidbody> ().velocity = Vector3.zero;
		is_ready = true;
		flied_Distance = 0;
		gameObject.SetActive (false);
	}

	bool isReady()
	{return is_ready;}
}