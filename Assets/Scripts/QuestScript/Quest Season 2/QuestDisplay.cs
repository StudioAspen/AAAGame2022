using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestDisplay : MonoBehaviour
{
    public GameObject myPrefab;
    public Transform parent;
    int current_quest = 0; //tracker to update quest list DISPLAY

    // Update is called once per frame
    void Update()
    {
        GameObject tempPrefab;
        int num_quest = FindObjectOfType<QuestManager>().all_quests.Count; //for current amount of quest in list

        if(!(num_quest == current_quest))
        {
            for (int i = parent.transform.childCount - 1; i >= 0; i--)
            {
                Destroy(parent.transform.GetChild(i).gameObject);
            }
            for (int i = 0; i < num_quest; i++)
            {
                tempPrefab = Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                Text test;
                tempPrefab.TryGetComponent<Text>(out test);
                test.text = FindObjectOfType<QuestManager>().all_quests[i].title;
                tempPrefab.transform.SetParent(parent);
                current_quest++;
            }
        }
    }
}
