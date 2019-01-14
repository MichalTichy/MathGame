using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{


    public static bool Enabled=true;
    public float moveSpeed=7f;
    public Transform character;
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
            character.rotation = new Quaternion(0, 180, 0, 0);
            animator.SetBool("isMoving", true);
        }
        else if(direction.x > 0)
        {
            character.rotation = new Quaternion(0,0,0,0);
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
        GetComponent<Rigidbody2D>().velocity = direction;
	}

}
