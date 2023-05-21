using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableGround : IMoveable
{
	[Header("Billboard")]
	[SerializeField]
	private GameObject billboardPrefab;
	[SerializeField]
	private float billboardOffsetY;

	private GameObject billboardInstance;

	[Header("Obstacles")]
	[SerializeField]
	private List<GameObject> obstaclePrefabs = new();

	[SerializeField]
	private GameObject winTriggerPrefab;

	private List<Obstacle> obstacles = new();

	public override void Setup(float moveSpeed, int indexInPool, float offsetY)
	{
		boundsSize = GetComponent<SpriteRenderer>().bounds.size;

		base.Setup(moveSpeed, indexInPool, offsetY);

		foreach (GameObject prefab in obstaclePrefabs)
		{
			GameObject spawnedPrefab = Instantiate(prefab, transform);
			spawnedPrefab.SetActive(false);
			obstacles.Add(spawnedPrefab.GetComponent<Obstacle>());
		}
		

		if(billboardInstance != null)
			DestroyImmediate(billboardInstance);

		if (indexInPool % 2 != 0)
		{
			billboardInstance = Instantiate(billboardPrefab, transform);
			billboardInstance.transform.localPosition = new Vector2(Random.Range(-boundsSize.x, boundsSize.x) / 1.5f, billboardOffsetY);
		}
	}

	public override void Respawn()
	{
		ResetObstacles();

		if(!PlayerController.flying && !GameManager.endGame)
			ChooseObstacle();		
	}

	private void SetObstaclePosition(Obstacle obstacle)
	{
		float randomPosX = Random.Range(-boundsSize.x / 3 + obstacle.boundsSize.x / 2f, boundsSize.x / 3 - obstacle.boundsSize.x / 2f);
		float posY = boundsSize.y / 2.2f;
		obstacle.transform.localPosition = new Vector2(randomPosX, posY);
	}

	private void ChooseObstacle()
	{
		int randIndex = Random.Range(0, obstaclePrefabs.Count);
		Obstacle obstacle = obstacles[randIndex];
		obstacle.gameObject.SetActive(true);

		SetObstaclePosition(obstacle);

		obstacle.Setup();
	}

	private void ResetObstacles()
	{
		foreach (Obstacle obs in obstacles)
		{
			obs.gameObject.SetActive(false);
		}
	}

	public void SpawnWinTrigger()
	{
		Debug.Log("SPAWN TRIGGER");
		Instantiate(winTriggerPrefab, transform);
	}
}
