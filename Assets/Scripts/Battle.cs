using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Battle : MonoBehaviour
{
    public Collider player;
    public Collider ground;
    public Collider trigger;

   
    private void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player") == true)
        {
            SceneManager.LoadScene("Battle");
            Debug.Log("Battle begins");
        }
       
        
    }

   
}
