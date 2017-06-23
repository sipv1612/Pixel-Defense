using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {
	public GameObject[] Enemy_Prefabs;
	public GameObject[] Turret_Prefabs;
	public Transform Spawn_point;
	public int Money;
	public int Enemy_Per_Wave = 1;
	public float Time_Between_Waves = 5.5f;
	public float Time_Wait_To_Spawn = 2f;
	public Text text_countdown;

	private float Time_Left_To_Spawn;

	void Start()
	{
		Time_Left_To_Spawn = Time_Wait_To_Spawn;
		text_countdown.text = "";
	}

	void Update()
	{
		if (Time_Left_To_Spawn < 0) {
			StartCoroutine (SpawnWave());
			Time_Left_To_Spawn = Time_Between_Waves;
		}

		Time_Left_To_Spawn -= Time.deltaTime;
		text_countdown.text = ((int)Time_Left_To_Spawn).ToString();
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
