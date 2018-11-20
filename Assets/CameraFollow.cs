using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    private Transform player;
    private Vector3 offset;


	public bool bounds;

	public Vector3 minCameraPosition;
	public Vector3 maxCameraPosition;

	private float xDiff;
	private float moveTrashold = 6;
	float speed=7f;

    // Use this for initialization
	void Start ()
	{
	    player = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate ()
	{
		// difference between camera and player position
		if (player.transform.position.x > transform.position.x) {	
			xDiff = player.transform.position.x - transform.position.x;
		} 
		else {
			xDiff = transform.position.x - player.transform.position.x;
		}
			
		if (xDiff >= moveTrashold) {
		
			offset = player.transform.position;

			transform.position = Vector3.MoveTowards(transform.position, offset, speed * Time.deltaTime );
		}

		if (bounds) {
		
			transform.position = new Vector3 (Mathf.Clamp(transform.position.x, minCameraPosition.x, maxCameraPosition.x),
				Mathf.Clamp(transform.position.y, minCameraPosition.y, maxCameraPosition.y),
				Mathf.Clamp(transform.position.z, minCameraPosition.z, maxCameraPosition.z));

		}
	    

	}
}
