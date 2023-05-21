using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMoveable : MonoBehaviour
{
	protected Rigidbody2D rb { get; set; }
	protected float moveSpeed;

	[HideInInspector]
	public Vector2 boundsSize { get; protected set; }


	public virtual void Setup(float moveSpeed, int indexInPool, float offsetY)
	{
		rb = GetComponent<Rigidbody2D>();



		this.moveSpeed = moveSpeed;

		rb.velocity = new Vector2(-moveSpeed, 0);

		Vector3 newPosition = new Vector3(boundsSize.x * indexInPool, offsetY);
		transform.position += newPosition;
		Debug.Log(moveSpeed + " " + indexInPool + " " + offsetY);
		name = name + "_" + indexInPool;
	}

	public void StopMoving()
	{
		rb.velocity = Vector2.zero;
	}
	public void ResumeMoving()
	{
		rb.velocity = new Vector2(-moveSpeed, 0);
	}

	public virtual void Respawn()
	{

	}
}
