using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraActivation : MonoBehaviour
{
    public Camera playerCamera;


    public void EnablePlayerCamera()
    {
        playerCamera.enabled = true;
    }



}

