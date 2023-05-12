using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D), typeof(Rigidbody2D))]
public class Coin : MonoBehaviour
{
    [SerializeField]
    private int coinNomVal;

    private CircleCollider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<CircleCollider2D>();

    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.CompareTag("Player"))
        {
            GameManager.UpdateScore(coinNomVal);
            gameObject.SetActive(false);
        }
	}


}
