using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal
{
    public bool isActive;
    public string description { get; set; }
    public bool isComplete { get; set; }
    public int currentAmount { get; set; }
    public int requiredAmount { get; set; }

    public Quest quest;

    public virtual void Init()
    {
        //default
    }

    public void Evaluate()
    {
        if (currentAmount >= requiredAmount)
            Complete();
    }

    public void Complete()
    {
        isComplete = true;
    }
}