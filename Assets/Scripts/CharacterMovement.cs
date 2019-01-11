using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{


    public static bool Enabled=true;
    public float moveSpeed=7f;
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    GetComponent<Rigidbody2D>().velocity = !Enabled ? 
            new Vector2(0,0) :
            new Vector2(moveSpeed * Input.GetAxis("Horizontal"),0);
	}

}
