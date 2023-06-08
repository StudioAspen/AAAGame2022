using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using System;

public class CameraRotation : MonoBehaviour 
{
    public Transform player;
    public Transform camera;

    float distance;
    public float offsetDistance;        // camera distance offset from player
    public float offsetHeight;          // camera height offset from player
    public float xRotation;

    bool isShaking;
    int currentShake = 0;
    public int shakeCount;
    public float shakeSpeed;
    public float shakeRange;
    Vector3 target;

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.M)) 
        {
            target = camera.localPosition + RandomJitter();
            isShaking = true;
        }

        transform.LookAt(player);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

        // excluding height, distance between pivot and player
        distance = (float)System.Math.Sqrt(System.Math.Pow(transform.position.x - player.position.x, 2f) + System.Math.Pow(transform.position.z - player.position.z, 2f));

        if (isShaking) 
        {
            if (Vector3.Distance(camera.localPosition, target) < 0.01f) 
            {
                currentShake++;
                if ((currentShake < shakeCount))
                {
                    target = camera.localPosition + RandomJitter();
                }
                else if (currentShake == shakeCount)
                {
                    target = new Vector3(0, player.position.y + offsetHeight, distance + offsetDistance);
                }
                else
                {
                    isShaking = false;
                    currentShake = 0;
                }
            }
            camera.localPosition = Vector3.MoveTowards(camera.localPosition, target, shakeSpeed);
        } 
        else 
        {
            camera.localPosition = new Vector3(0, player.position.y + offsetHeight, distance + offsetDistance);
        }
        Vector3 newRotation = new Vector3(xRotation, camera.rotation.eulerAngles.y, camera.rotation.eulerAngles.z);
        camera.rotation = Quaternion.Euler(newRotation);
    }

    Vector3 RandomJitter() 
    {
        return new Vector3 (Random.Range(-shakeRange, shakeRange), Random.Range(-shakeRange, shakeRange), 0);
    }

}
