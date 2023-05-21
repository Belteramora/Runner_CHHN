using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class AnimatedBuilding : MonoBehaviour
{
    public static event Action OnBuildStopped;
    public static event Action OnPlayerGoToDoor;

    private Rigidbody2D rb;
    [SerializeField]
    private Animator doorAnimator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-6f, 0);
    }


	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision != null)
        {
            if (collision.CompareTag("StopTrigger"))
            {
                rb.velocity = Vector2.zero;
                if(OnBuildStopped != null)
                    OnBuildStopped();

				doorAnimator.Play("DoorAnim");
            }

            if (collision.CompareTag("Player"))
            {
                if(OnPlayerGoToDoor != null)
                {
                    doorAnimator.Play("DoorCloseAnim");
                    OnPlayerGoToDoor();
                }
            }
        }
	}

	private void OnDestroy()
	{
        OnBuildStopped = null;
        OnPlayerGoToDoor = null;
	}

}
