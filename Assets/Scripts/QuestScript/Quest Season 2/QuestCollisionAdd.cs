using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestCollisionAdd : MonoBehaviour
{
    public Quest first_quest;
    public bool canEnter = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && canEnter)
        {
            first_quest.is_complete = false;
            //if quest added already
            if (FindObjectOfType<QuestManager>().FindQuest(first_quest))
            {
                Debug.Log(first_quest + " added already");
            }
            //quest has not been added
            if (!(FindObjectOfType<QuestManager>().FindQuest(first_quest)))
            {
                FindObjectOfType<QuestManager>().AddQuest(first_quest);
                FindAnyObjectByType<QuestDisplay>().DisplayUpdate();
                Debug.Log(first_quest + " added, quest count " + FindObjectOfType<QuestManager>().all_quests.Count);
            }
            canEnter = false;
        }
    }
}
