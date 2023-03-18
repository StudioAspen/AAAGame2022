using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Battle : MonoBehaviour
{
    public Collider player;
    public Collider ground;
    public Collider trigger;
    public GameObject character;

    public bool battleScene = false;

    [SerializeField]
    private CharacterStats characterStats;

    bool canEnter = true;
    GameObject[] overworldObjects;
    public List<CombatData> players;
    public List<CombatData> enemies;

    void Update()
    {
        characterStats.overworldPos = character.transform.position;
    }

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
            //Disabling all objects
            foreach (GameObject a in overworldObjects)
            {
                a.SetActive(false);
            }
            combatController.InitalizeCombat(players, enemies);
        }
    }




    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && canEnter)
        {
            canEnter = false;
            characterStats.battleScene = true;
            Debug.Log("Battle begins");
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
