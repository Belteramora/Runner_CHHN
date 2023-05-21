using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableGroundPool : MoveablePool
{
	private bool isTriggerSpawned = false;
	protected override void Setup()
	{
		base.Setup();
		GameManager.GameWinned += OnGameWinned;
		RespawnTrigger.onGroundRespawn += RemoveAndSpawnNew;
	}

	public override void RemoveAndSpawnNew(GameObject movableObject)
	{
		base.RemoveAndSpawnNew(movableObject);

		if(isTriggerSpawned)
		{
		
			MoveableGround ground = movableObject.GetComponent<MoveableGround>();
			ground.SpawnWinTrigger();
			isTriggerSpawned=false;
		}
	}

	public void OnGameWinned()
	{
		isTriggerSpawned=true;
	}
}
