using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{

    public GameObject TeleportedObject;

    public bool AllowUp;

    public bool AllowDown;

    public Transform TargetPositionUp;

    public Transform TargetPositionDown;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay2D(Collider2D other)
    {
        bool teleported = false;
        if (AllowUp && Input.GetKeyDown(KeyCode.W))
        {
            TeleportedObject.transform.position = TargetPositionUp.transform.position;
            teleported = true;
        }
        else if (AllowDown && Input.GetKeyDown(KeyCode.S))
        {
            TeleportedObject.transform.position = TargetPositionDown.transform.position;
            teleported = true;
        }
    }
}
