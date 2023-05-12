using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public static event Action AutoPlaySetup;

    [SerializeField]
    private GameObject coinsTrailPrefab;

    private GameObject coinsTrail;

    private bool isTriggered = false;
    [HideInInspector]
    public Vector2 boundsSize;

	private void Awake()
	{
        AutoPlaySetup = null;
	}

	private void Start()
	{
        boundsSize = GetComponent<SpriteRenderer>().bounds.size;
	}

	private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !isTriggered)
        {
            isTriggered = true;
            collision.GetComponent<PlayerController>().BeDamaged();
        }
    }

    public void Setup()
    {
        isTriggered = false;

        if(coinsTrail != null)
        {
            Destroy(coinsTrail);
        }

        coinsTrail = Instantiate(coinsTrailPrefab, transform);

        if(AutoPlaySetup != null) 
            AutoPlaySetup();
        
    }
}
