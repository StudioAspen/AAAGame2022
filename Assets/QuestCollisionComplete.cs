using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestCollisionComplete : MonoBehaviour
{
    public Quest first_quest;
    public bool canEnter = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && canEnter)
        {
            //if quest is not completed
            //Debug.Log("quest not completed);
            //else

            //completes quest
            FindObjectOfType<QuestManager>().CompleteQuest(first_quest);
            FindAnyObjectByType<QuestDisplay>().DisplayUpdate();
            Debug.Log(first_quest + " is complete");
            canEnter = false;
        }
    }
}
