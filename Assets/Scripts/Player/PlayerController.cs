using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private GroundChecker groundChecker;
    private Animator animator;

    private GameObject spriteHolder;

    private int currentHP;
	private float animSpeed;
    private float coctailY;

    private Vector2 savedVelocity;
    private RigidbodyType2D savedType;

	private bool ableDoubleJump = false;

    [SerializeField]
    private Vector2 jumpForce;
    [SerializeField]
    private float groundCheckDistance;
    [SerializeField]
    private int maximumHP;

	public bool inSlide = false;

    public static event Action<int> OnLoseHP;

    public static bool flying = false;

	private void Awake()
	{
		GameManager.GamePaused += StopAnimation;
		GameManager.GameResumed += ResumeAnimation;
		GameManager.GameEnded += StopAnimation;

		rb2d = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		groundChecker = GetComponentInChildren<GroundChecker>();
	}

	// Start is called before the first frame update
	void Start()
    {

        if (GameManager.CurrentSkinData != null) 
        {
            animator.runtimeAnimatorController = GameManager.CurrentSkinData.currentSkin;

            Debug.Log(transform.GetChild(1).name);

            transform.GetChild(1).localPosition = GameManager.CurrentSkinData.offsetPosition;

		}

        groundChecker.SetVariables(groundCheckDistance);

        currentHP = maximumHP;
    }

	// Update is called once per frame
	void Update()
    {
        animator.SetBool("isOnGround", groundChecker.IsOnGround());
        animator.SetFloat("velocityY", rb2d.velocity.y);

        if (flying)
        {
            rb2d.MovePosition(new Vector2(transform.position.x, coctailY));
        }
    }

    public void Jump()
    {
        if (groundChecker.IsOnGround() && !inSlide)
        {
            rb2d.velocity = jumpForce;
            ableDoubleJump = true;
        }
        else if (ableDoubleJump)
        {
            rb2d.velocity = jumpForce + new Vector2(0, 2);
            ableDoubleJump = false;
		}
    }

    public void Slide()
    {

        if(groundChecker.IsOnGround())
        {
			ableDoubleJump = false;
			animator.SetTrigger("inSlide");
        }
    }

    public void StopAnimation(bool isWin)
    {
        StopAnimation();
    }

	public void StopAnimation()
	{
		animSpeed = animator.speed;
		animator.speed = 0f;
		savedVelocity = rb2d.velocity;
		savedType = rb2d.bodyType;
		rb2d.bodyType = RigidbodyType2D.Static;
	}


	public void ResumeAnimation()
    {
		animator.speed = animSpeed;
		rb2d.bodyType = savedType;
		rb2d.velocity = savedVelocity;
	}

    public void BeDamaged()
    {
        currentHP--;

        animator.SetTrigger("beDamaged");

        OnLoseHP(currentHP);

        if(currentHP <= 0)
        {
            animator.SetTrigger("death");
            GameManager.GameOver(false);
        }
    }

    public void Flying(float coctailYPosition)
    {
        coctailY = coctailYPosition;

		flying = true;
		rb2d.bodyType = RigidbodyType2D.Kinematic;
		rb2d.velocity = Vector2.zero;
	}

    public void StopFlying()
    {
		rb2d.bodyType = RigidbodyType2D.Dynamic;
        flying = false;
	}

    
}
