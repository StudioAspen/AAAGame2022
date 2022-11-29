using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Camera _mainCamera;


    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray _ray;
            _ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

            Debug.DrawLine(_ray.GetPoint(0f), _ray.direction *100, Color.blue, 10f);

            RaycastHit _hit;
            if (Physics.Raycast(_ray, out _hit, 1000f))
            {
                Debug.Log("Click");
            }
        }
    }
}
