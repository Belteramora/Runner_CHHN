using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableBackground : IMoveable
{
	public override void Setup(float moveSpeed, int indexInPool, float offsetY)
	{
		boundsSize = GetComponentsInChildren<SpriteRenderer>()[0].bounds.size;

		base.Setup(moveSpeed, indexInPool, offsetY);

		transform.position = new Vector3(transform.position.x - 0.1f * indexInPool, transform.position.y);
		
	}

}
