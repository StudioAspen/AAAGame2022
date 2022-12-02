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
            Quest quest = FindObjectOfType<NPC>().quest_;
            Debug.Log(quest.title);
            FindObjectOfType<DisableRoot>().gameObject.SetActive(false);
            CombatController combatController = FindObjectOfType<CombatController>();
            Debug.Log(combatController.name);
            if(combatController != null)
            {
                FindObjectOfType<CombatController>().SaveOverWorld(quest);
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
