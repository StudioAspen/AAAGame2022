using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class Quest
{
    public string title { get; set; }
    public string description { get; set; }
    public int xpReward { get; set; }
    public int goldReward { get; set; }

    public bool isActive;
    public bool isComplete { get; set; }

    public List<QuestGoal> goals { get; set; } = new List<QuestGoal>();

    public void CheckGoals()
    {
        isComplete = goals.All(g => g.isComplete);
        if (isComplete)
            GiveReward(); 
    }

    void GiveReward()
    {
        //if(quest is done or item is in inventory)
            //give a reward
    }
}
