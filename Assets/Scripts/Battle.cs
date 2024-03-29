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
    // private CharacterStats characterStats;

    bool canEnter = true;
    List<GameObject> overworldObjects = new List<GameObject>();
    public BattleData battleData;

    // void Update()
    // {
    //     characterStats.overworldPos = character.transform.position;
    // }

    IEnumerator TriggerCombat(BattleData _battleData)
    {
        //Getting all objects to disable in current scene
        //overworldObjects = FindObjectsOfType<GameObject>();
        GameObject playerObject = FindObjectOfType<CharacterMovement>().gameObject;
        CameraRotation cameraRotation = FindObjectOfType<CameraRotation>();
        //cameraTransform.SetParent(playerObject.transform.parent);
        overworldObjects.Add(playerObject);
        overworldObjects.Add(FindObjectOfType<AudioController>().gameObject);
        Canvas[] canvases = FindObjectsOfType<Canvas>();
        foreach (Canvas canvas in canvases)
        {
            overworldObjects.Add(canvas.gameObject);
        }

        //Load Combat Scene and waiting for it to load
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("CombatScene", LoadSceneMode.Additive);
        yield return new WaitUntil(() => asyncLoad.isDone);

        //Passing data to combat controller
        CombatController combatController = FindObjectOfType<CombatController>();
        if (combatController != null)
        {
            combatController.SaveOverWorld(overworldObjects);
            combatController.SetRootTransform(playerObject.transform);
            combatController.SetCameraPos(cameraRotation);
            combatController.InitalizeCombat(_battleData.players, _battleData.enemies);
            combatController.SetBattleEndEvent(_battleData.afterCombat);
            combatController.SetScriptedLoss(battleData.scriptedLoss);
        }
        //Disabling all objects
        foreach (GameObject a in overworldObjects)
        {
            a.SetActive(false);
        }
    }

    public void StartCombat(BattleData _battleData)
    {
        StartCoroutine(TriggerCombat(_battleData));
    }


    // private void OnTriggerEnter(Collider other)
    // {
    //     if(other.CompareTag("Player") && canEnter)
    //     {
    //         canEnter = false;
    //         characterStats.battleScene = true;
    //         Debug.Log("Battle begins");
    //         StartCoroutine(TriggerCombat(battleData));
    //     }
    // }
    
    // private void OnTriggerExit(Collider other)
    // {
    //     if (other.CompareTag("Player") == true)
    //     {
    //         canEnter = true;
    //     }
    // }


}
