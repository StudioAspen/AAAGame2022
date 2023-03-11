using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestDisplay : MonoBehaviour
{
    public GameObject myPrefab;
    public Transform parent;

    // Update is called once per frame
    void Update()
    {
        GameObject tempPrefab;
        int num_quest = FindObjectOfType<QuestManager>().all_quests.Count; //for current amount of quest in list
        int current_quest = 0; //tracker to update quest list DISPLAY

        //when a new quest has been added
        if(!(num_quest > current_quest)) {
            for (int i = 0; i < num_quest; i++)
            {
                tempPrefab = Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                Text test;
                tempPrefab.TryGetComponent<Text>(out test);
                test.text = FindObjectOfType<QuestManager>().all_quests[current_quest].title;
                tempPrefab.transform.SetParent(parent);
                current_quest++;
            }
            Debug.Log(current_quest + " = quest displayed, " + num_quest + " = quests in list");
        }

        //when a quest has been completed and removed
        /*
        if (num_quest < current_quest)
        {
            for (int i = 0; i < num_quest; i++)
            {
                tempPrefab = Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                Text test;
                tempPrefab.TryGetComponent<Text>(out test);
                test.text = "quest name";
                tempPrefab.transform.SetParent(parent);
                current_quest = num_quest;
            }
            enabled = false;
            current_quest = num_quest;
        }
        */

        void DisplayUpdate(List<Quest> list) {
            for (int i = 0; i < num_quest; i++)
            {
                tempPrefab = Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                Text test;
                tempPrefab.TryGetComponent<Text>(out test);
                test.text = FindObjectOfType<QuestManager>().all_quests[current_quest].title;
                tempPrefab.transform.SetParent(parent);
                current_quest++;
            }
        }
    }
}
