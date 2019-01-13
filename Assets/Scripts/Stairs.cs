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
                TeleportedObject.transform.position = TargetPositionUp.transform.position;
            else
                AccessDeniedUpInteraction?.StartInteraction();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if(AllowDown)
                TeleportedObject.transform.position = TargetPositionDown.transform.position;
            else
                AccessDeniedDownInteraction?.StartInteraction();
        }
    }
}
