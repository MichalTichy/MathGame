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

    public CharacterInteraction AccessDeniedUpInteraction;

    public CharacterInteraction AccessDeniedDownInteraction;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (AllowUp)
                GoUp();
            else
                AccessDeniedUpInteraction?.StartInteraction();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (AllowDown)
                GoDown();
            else
                AccessDeniedDownInteraction?.StartInteraction();
        }
    }

    public void GoUp()
    {
        TeleportedObject.transform.position = TargetPositionUp.transform.position;
    }

    public void GoDown()
    {

        TeleportedObject.transform.position = TargetPositionDown.transform.position;
    }
}
