using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Battle : MonoBehaviour
{
    bool canEnter = true;
    GameObject[] overworldObjects;
    public List<GameObject> enemies;

    IEnumerator TriggerCombat()
    {
        //Getting all objects to disable in current scene
        overworldObjects = FindObjectsOfType<GameObject>();


        //Load Combat Scene and waiting for it to load
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("CombatScene", LoadSceneMode.Additive);
        yield return new WaitUntil(() => asyncLoad.isDone);


        //Passing data to combat controller
        CombatController combatController = FindObjectOfType<CombatController>();
        if (combatController != null)
        {
            combatController.SaveOverWorld(overworldObjects);
        }


        //Disabling all objects
        foreach (GameObject a in overworldObjects)
        {
            a.SetActive(false);
        }
    }




    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && canEnter)
        {
            canEnter = false;
            StartCoroutine(TriggerCombat());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") == true)
        {
            canEnter = true;
        }
    }


}
