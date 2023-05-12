using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableGroundPool : MoveablePool
{
	protected override void Setup()
	{
		base.Setup();
		RespawnTrigger.onGroundRespawn += RemoveAndSpawnNew;
	}
}
