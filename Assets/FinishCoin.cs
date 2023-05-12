using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCoin : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision != null)
		{
			if (collision.CompareTag("Player"))
			{
				collision.GetComponent<PlayerController>().StopFlying();
			}
		}
	}
}
