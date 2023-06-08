using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    private float radius = 2f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void PointTo(Vector3 target)
    {
        Vector3 targetVector = target - transform.position;
        Debug.DrawRay(transform.position, targetVector);
        transform.right = targetVector.normalized;
        transform.position = transform.parent.position + targetVector.normalized * radius;
    }
    public void SetRadius(float _radius)
    {
        radius = _radius;
    }

}
