using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
	public Transform[] spawnPoints;
	public GameObject[] enemyPrefabs;
	public float startSpawnTime = 1;
	private float spawnTime;
	public int maxEnemyCount = 10;

	private void Start()
	{
		spawnTime = startSpawnTime;
	}

	private void Update()
	{
		if(spawnTime <= 0 && maxEnemyCount > 0)
		{
			int randEnemy = Random.Range(0, enemyPrefabs.Length);
			int randSpawnPoint = Random.Range(0, spawnPoints.Length);
			Instantiate(enemyPrefabs[0], spawnPoints[randSpawnPoint].position, Quaternion.identity);
			spawnTime = startSpawnTime;
			maxEnemyCount -= 1;
		} else {
			spawnTime -= Time.deltaTime;
		}
	}
}
