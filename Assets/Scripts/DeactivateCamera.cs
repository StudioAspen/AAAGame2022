using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateCamera : MonoBehaviour
{
    public Camera cameraToDeactivate;

    private void Awake()
    {
        if (cameraToDeactivate != null)
        {
            cameraToDeactivate.gameObject.SetActive(false);
        }
    }
}
