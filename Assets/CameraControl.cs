using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public Camera TargetCamera;
    public void SwitchToCamera()
    {
        Camera.SetupCurrent(TargetCamera);
    }
}
