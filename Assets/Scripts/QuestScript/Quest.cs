using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "Data", menuName = "QuestData")]
public class Quest : ScriptableObject
{
    public string title;
    public string description;
    public bool is_complete;
    public bool handed_in;
    public Quest() { }
    public Quest(Quest quest)
    {
        title = quest.title;
        description = quest.description;
        is_complete = quest.is_complete;
        handed_in = quest.handed_in;
    }
}
