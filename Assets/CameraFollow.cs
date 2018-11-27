using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;


    public bool bounds;

    public Vector3 minCameraPosition;
    public Vector3 maxCameraPosition;

    private float moveTrashold = 6;
    public float speed;
    public float offset;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        transform.position = player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //if (xDiff >= moveTrashold)
        //{
        //    transform.position = new Vector3(player.transform.position.x - moveTrashold, player.transform.position.y + offset,
        //        transform.position.z);
        //}
        //else if (xDiff <= -moveTrashold)
        //{
        //    transform.position = new Vector3(player.transform.position.x + moveTrashold, player.transform.position.y + offset,
        //        transform.position.z);
        //}

        Vector3 newPos = player.transform.position;
        newPos.y += offset;
        transform.position = Vector3.Lerp(transform.position, newPos, speed * Time.deltaTime);

        if (bounds)
        {

            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, minCameraPosition.x, maxCameraPosition.x),
                Mathf.Clamp(transform.position.y, minCameraPosition.y, maxCameraPosition.y),
                Mathf.Clamp(transform.position.z, minCameraPosition.z, maxCameraPosition.z));

        }
    }
 
}
