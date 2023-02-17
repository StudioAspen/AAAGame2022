using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestDisplay : QuestManager
{
    public GameObject myPrefab;
    public Transform parent;

    // Start is called before the first frame update
    void Start()
    {
        GameObject tempPrefab;
        int num_quest = all_quests.Capacity;
        for (int i = 0; i < 3; i++)
        {
            tempPrefab = Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            Text test;
            tempPrefab.TryGetComponent<Text>(out test);
            test.text = "shit";
            tempPrefab.transform.SetParent(parent);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*
    void QuestCheck()
    {
        int quest_count = 0;
        int num_quest = all_quests.Capacity;

        if (quest_count == num_quest)
        {

        }
    }
        */
}
