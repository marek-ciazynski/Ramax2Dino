using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Collider2D foodCollider;
    public CharacterController2D controller;
	public Animator animator;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;
	private int foodInDinoHeadZone = 0;

	// Update is called once per frame
	void Update()
	{
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		animator.SetFloat("Speed", Math.Abs(horizontalMove));

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			animator.SetBool("IsJumping", true);
		}

		if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		}
		else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}

		if (Input.GetButtonDown("Fire1"))
		{
			animator.SetBool("IsEating", true);
			Debug.Log("Dino fire1");
		}
		else if (Input.GetButtonUp("Fire1"))
		{
			animator.SetBool("IsEating", false);
			Debug.Log("Dino NOT fire1");
		}
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
		foodInDinoHeadZone += 1;
        animator.SetBool("IsEating", true);
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        foodInDinoHeadZone -= 1;
		if (foodInDinoHeadZone == 0)
		{
            animator.SetBool("IsEating", false);
        }
    }

    public void OnLanded()
	{
		animator.SetBool("IsJumping", false);
	}

    void FixedUpdate()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}
}
