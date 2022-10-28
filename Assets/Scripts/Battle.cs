using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    public Collider player;
    public Collider ground;
    public Collider trigger;

   
    private void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player") == true)
        {
            Debug.Log("Battle begins");
        }
       
        
    }

   
}
