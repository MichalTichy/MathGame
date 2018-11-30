using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Player;
    public Vector2 MinPoint;
    public Vector2 MaxPoint;
    public float yCameraOffset = 2.5f;
    public float speed = 2;

    private Vector3 minCameraPosition;
    private Vector3 maxCameraPosition;
    

    // Use this for initialization
    void Start()
    {
        float screenHeightInUnits = Camera.main.orthographicSize * 2;
        float screenWidthInUnits = screenHeightInUnits * Screen.width / Screen.height;
        minCameraPosition= new Vector2(MinPoint.x + screenWidthInUnits / 2, MinPoint.y + screenHeightInUnits / 2);
        
        maxCameraPosition = new Vector2(MaxPoint.x - screenWidthInUnits / 2, MaxPoint.y - screenHeightInUnits / 2);
    }

    // Update is called once per frame
    void LateUpdate()
    {

        Vector3 newPos = Player.transform.position;
        newPos.y += yCameraOffset;
        transform.position = Vector3.Lerp(transform.position, newPos, speed * Time.deltaTime);
        
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, minCameraPosition.x, maxCameraPosition.x),
            Mathf.Clamp(transform.position.y, minCameraPosition.y, maxCameraPosition.y),
            -10);
    }
 
}
