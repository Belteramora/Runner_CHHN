using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
	public static event Action onWinTriggerEnter;
	[SerializeField]
	private GameObject barPrefab;

	[SerializeField]
	private GameObject stopTriggerPrefab;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision != null)
		{
			if (collision.CompareTag("Player"))
			{
				//TODO: �������� ������� �������� UI
				onWinTriggerEnter();
				GameManager.isGameActive = false;

				Instantiate(barPrefab);
				Instantiate(stopTriggerPrefab);
			}
		}
	}

	private void OnDestroy()
	{
		onWinTriggerEnter = null;
	}
}
