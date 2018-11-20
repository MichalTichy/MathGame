using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    private Transform player;
    private Vector3 offset;


	public bool bounds;

	public Vector3 minCameraPosition;
	public Vector3 maxCameraPosition;

    // Use this for initialization
	void Start ()
	{
	    player = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate ()
	{

		transform.position = player.position + offset;

		if (bounds) {
		
			transform.position = new Vector3 (Mathf.Clamp(transform.position.x, minCameraPosition.x, maxCameraPosition.x),
				Mathf.Clamp(transform.position.y, minCameraPosition.y, maxCameraPosition.y),
				Mathf.Clamp(transform.position.z, minCameraPosition.z, maxCameraPosition.z));

		}
	    

	}
}
