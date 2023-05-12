using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnTrigger : MonoBehaviour
{
    public static event Action<GameObject> onBackgroundRespawn;
    public static event Action<GameObject> onGroundRespawn;

	private void Awake()
	{
        onBackgroundRespawn = null;
		onGroundRespawn = null;
	}

	private void OnTriggerEnter2D(Collider2D collision)
    {
		if (collision.CompareTag("Background"))
			onBackgroundRespawn.Invoke(collision.gameObject);
		else if (collision.CompareTag("Ground"))
			onGroundRespawn.Invoke(collision.gameObject);
		else if (collision.CompareTag("Coctail"))
			Destroy(collision.gameObject);
	}

}
