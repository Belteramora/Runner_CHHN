using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class AutoPlayObstacle : MonoBehaviour
{
	[SerializeField]
	public Actions action;

	private BoxCollider2D boxCollider;
	public void Start()
	{
		Obstacle.AutoPlaySetup += Setup;
		GameManager.OnAutoPlayEnabled += OnAutoPlayEnabled;
	}

	public void Setup()
	{

		boxCollider = GetComponent<BoxCollider2D>();

		if (GameManager.autoPlayed)
		{
			boxCollider.enabled = true;
		}
		else
		{
			boxCollider.enabled = false;
		}
	}

	public void OnAutoPlayDisabled()
	{
		if(boxCollider != null)
			boxCollider.enabled = false;
	}

	public void OnAutoPlayEnabled()
	{
		if (boxCollider != null)
			boxCollider.enabled = true;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			StartCoroutine(DoAction(collision.GetComponent<PlayerController>()));
		}
	}

	private IEnumerator DoAction(PlayerController controller)
	{
		switch (action)
		{
			case Actions.Jump:
				controller.Jump();
				break;
			case Actions.Slide:
				controller.Slide();
				break;
			case Actions.DoubleJump:
				controller.Jump();
				yield return new WaitForSeconds(0.5f);
				break;
		}

		yield return null;
	}

	public enum Actions
	{
		Jump,
		Slide,
		DoubleJump
	}
}
