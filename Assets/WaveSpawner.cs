using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {
	public GameObject[] Enemy_Prefabs;
	public GameObject[] Turret_Prefabs;
	public int Money;
	public Transform Spawn_point;
	public int Enemy_Per_Wave = 1;
	public float Time_Between_Waves = 5f;
	public float Time_Wait_To_Spawn = 2f;
	public float Time_Left_To_Spawn;

	void Start()
	{
		Time_Left_To_Spawn = Time_Wait_To_Spawn;
	}

	void Update()
	{
		if (Time_Left_To_Spawn < 0) {
			StartCoroutine (SpawnWave());
			Time_Left_To_Spawn = Time_Between_Waves;
		}

		Time_Left_To_Spawn -= Time.deltaTime;
	}

	IEnumerator SpawnWave(){
		for (int i = 0; i < Enemy_Per_Wave; i++) {
			SpawnEnemy ();
			yield return new WaitForSeconds (0.5f);
		}
		Enemy_Per_Wave++;
	}

	void SpawnEnemy()
	{
		Instantiate (Enemy_Prefabs[0], Spawn_point.position, Spawn_point.rotation);
	}
}
