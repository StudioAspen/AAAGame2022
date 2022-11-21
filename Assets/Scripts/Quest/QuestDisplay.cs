using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class QuestDisplay : MonoBehaviour
{
    public Quest quest;

    public TextMeshProUGUI Qtitle;
    public TextMeshProUGUI Qdescription;

    private QuestManager questManager;
    private GameObject QuestListMenu;
    private GameObject QuestMenu;

    // Start is called before the first frame update
    void Start()
    {
        Qtitle.text = quest.title;
        Qdescription.text = quest.description;
    }

    void QuestListDisplay(List<Quest> list_quests)
    {

    }

    void QuestDetailDisplay(Quest quest)
    {

    }
}