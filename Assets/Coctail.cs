using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coctail : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.GamePaused += StopMoving;
        GameManager.GameResumed += ResumeMoving;

        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.left * 6;
    }

    private void StopMoving()
    {
        rb.velocity = Vector3.zero;
    }

    private void ResumeMoving()
    {
        rb.velocity = Vector3.left * 6;
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision != null)
        {
            if (collision.CompareTag("Player"))
            {
                collision.GetComponent<PlayerController>().Flying(transform.position.y);
                GetComponent<SpriteRenderer>().enabled = false;
                
            }
        }
	}

	private void OnDestroy()
	{
		GameManager.GamePaused -= StopMoving;
		GameManager.GameResumed -= ResumeMoving;
	}
}
