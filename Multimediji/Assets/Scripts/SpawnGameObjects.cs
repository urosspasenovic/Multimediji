
using UnityEngine;
using System.Collections;

public class SpawnGameObjects : MonoBehaviour
{

	[SerializeField]
	float secondsBetweenSpawning = 0.1f;
	[SerializeField]
	float xMinRange = -25.0f;
	[SerializeField]
	float xMaxRange = 25.0f;
	[SerializeField]
	float yMinRange = 8.0f;
	[SerializeField]
	float yMaxRange = 25.0f;
	[SerializeField]
	float zMinRange = -25.0f;
	[SerializeField]
	float zMaxRange = 25.0f;
	[SerializeField]
	GameObject[] spawnObjects;
	private float nextSpawnTime;

	void Start()
	{
		nextSpawnTime = Time.time + secondsBetweenSpawning;
	}

	void Update()
	{
		if (GameManager.gm.gameIsOver)
			return;

		if (Time.time >= nextSpawnTime)
		{
			MakeThingToSpawn();
			nextSpawnTime = Time.time + secondsBetweenSpawning;
		}
	}

	void MakeThingToSpawn()
	{
		Vector3 spawnPosition;

		spawnPosition.x = Random.Range(xMinRange, xMaxRange);
		spawnPosition.y = Random.Range(yMinRange, yMaxRange);
		spawnPosition.z = Random.Range(zMinRange, zMaxRange);

		int objectToSpawn = Random.Range(0, spawnObjects.Length);

		GameObject spawnedObject = Instantiate(spawnObjects[objectToSpawn], spawnPosition, transform.rotation) as GameObject;

		spawnedObject.transform.parent = gameObject.transform;
	}
}
