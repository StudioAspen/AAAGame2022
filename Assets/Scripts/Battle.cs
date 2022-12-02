using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Battle : MonoBehaviour
{
    public Collider player;
    public Collider ground;
    public Collider trigger;
    bool canEnter = true;
   
    private void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player") == true && canEnter)
        {
            canEnter = false;
            SceneManager.LoadScene("CombatScene", LoadSceneMode.Additive);
            FindObjectOfType<DisableRoot>().gameObject.SetActive(false);
            CombatController combatController = FindObjectOfType<CombatController>();
            if(combatController != null)
            {
                FindObjectOfType<CombatController>().SaveOverWorld(FindObjectOfType<NPC>().quest_);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (player.CompareTag("Player") == true)
        {
            canEnter = true;
        }
    }


}
