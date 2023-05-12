using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableBackgroundPool : MoveablePool
{
	public override void RemoveAndSpawnNew(GameObject movableObject)
	{
		base.RemoveAndSpawnNew(movableObject);
		movableObject.transform.position = new Vector3(movableObject.transform.position.x - 0.1f, movableObject.transform.position.y);
	}

	protected override void Setup()
	{
		base.Setup();

		RespawnTrigger.onBackgroundRespawn += RemoveAndSpawnNew;
	}
}
