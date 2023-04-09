using System;
using System.Collections.Generic;
using UnityEngine;


public class NPCFollow : MonoBehaviour
{
    public GameObject leader; // the game object to follow - assign in inspector
    public int steps; // number of steps to stay behind - assign in inspector


    private Queue<Vector3> record = new Queue<Vector3>();
    private Vector3 lastRecord;
    float minDist = 3f;
    public Animator anim;



    private void Start()
    {

        anim = GetComponent<Animator>();

    }

    void FixedUpdate()
    {

        float dist = Vector3.Distance(GameObject.Find("Player").transform.position, transform.position);
        // record position of leader
        record.Enqueue(leader.transform.position);

        var pos = GetComponent<Rigidbody>().position;
        var move = GetComponent<Rigidbody>().velocity;



        // remove last position from the record and use it for our own
        Debug.DrawRay(pos, GameObject.Find("Player").transform.position - pos, Color.green, dist);
        if (record.Count > steps /*&& (dist > minDist)*/)
        {
            var next = record.Dequeue();
            

            if (move != Vector3.zero)
            {
                anim.SetFloat("X", move.x);
                anim.SetFloat("Y", move.y);
                anim.SetBool("Walking", true);
            }

        }
        else
        {
            anim.SetBool("Walking", false);
        }


    }
}
