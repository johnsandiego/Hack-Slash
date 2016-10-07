using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	public GameObject[] enemies;
	public int amount;
	private Vector3 spawnPoint;

	
	// Update is called once per frame
	void Update () {
		enemies = GameObject.FindGameObjectsWithTag("Enemy");

		amount = enemies.Length;
		if(amount != 3)
		{
			InvokeRepeating("spawnEnemy", 5, 10f);

		}
	}
	void spawnEnemy(){

		spawnPoint.x = Random.Range(80,120);
		spawnPoint.x = .5f;
		spawnPoint.z = Random.Range(140,170);

		Instantiate(enemies[UnityEngine.Random.Range(0,enemies.Length-1)],spawnPoint,Quaternion.identity);
		CancelInvoke();
	}
}
