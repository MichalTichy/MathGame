using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed=7f;
    public SpriteRenderer characterRenderer;
    public Animator animator;
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
        Vector2 direction = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), 0);
        if(direction.x < 0)
        {
            characterRenderer.flipX = true;
            animator.SetBool("isMoving", true);
        }
        else if(direction.x > 0)
        {
            characterRenderer.flipX = false;
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
        GetComponent<Rigidbody2D>().velocity = direction;
	}

    public void GoToPositionOnX(int x, int speed)
    {
        StartCoroutine(GoToPositionOnXCoroutine(x,speed));
    }

    private IEnumerator GoToPositionOnXCoroutine(int x, int speed)
    {
        float diference = Math.Abs(transform.position.x - x);
        while (diference > 0.1f)
        {
            animator.SetBool("isMoving", true);
            if (diference > 0)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);
                characterRenderer.flipX = true;
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
                characterRenderer.flipX = false ;
            }
            diference = Math.Abs(transform.position.x - x);
            yield return null;
        }
        animator.SetBool("isMoving", false);
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    public void Stop()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        animator.SetBool("isMoving", false);
    }

}
