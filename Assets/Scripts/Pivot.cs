using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot : MonoBehaviour
{
    public Transform camera;

    void Update()
    {
        transform.LookAt(camera);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    }
}
