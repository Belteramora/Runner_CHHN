using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveablePool : ObjectsPool<IMoveable>
{
	[SerializeField]
	protected float moveSpeed;

	[SerializeField]
	protected float offsetY;

	protected int lastIndex = 0;
	// Start is called before the first frame update
	protected override void Setup()
	{
		base.Setup();

		for (int i = 0; i < poolSize; i++)
		{
			pool[i].Setup(moveSpeed, i, offsetY);
		}

		lastIndex = poolSize - 1;
	}

	public void StopMoving()
	{
		foreach(IMoveable moveable in pool)
		{
			moveable.StopMoving();
		}
	}

	public void ResumeMoving()
	{
		foreach (IMoveable moveable in pool)
		{
			moveable.ResumeMoving();
		}
	}

	public virtual void RemoveAndSpawnNew(GameObject movableObject)
	{
		float previousX = pool[lastIndex].transform.position.x;

		IMoveable moveableScript = movableObject.GetComponent<IMoveable>();

		movableObject.transform.position = new Vector3(previousX + moveableScript.boundsSize.x, movableObject.transform.position.y);

		moveableScript.Respawn();

		lastIndex = pool.FindIndex((x) => x == moveableScript);
	}
}
