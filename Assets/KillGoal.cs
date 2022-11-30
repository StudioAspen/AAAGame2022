using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillGoal : QuestGoal
{
    // public int EnemyID { get; set; }
    // to check what type of enemy needs to be killed
    // each enemy will have its own ID

    public KillGoal(Quest quest, int ID, string des, bool completed, int currentA, int requiredA)
    {
        this.quest = quest;
        //this.EnemyID = enemyID;
        this.description = des;
        this.isComplete = completed;
        this.currentAmount = currentA;
        this.requiredAmount = requiredA;
    }

    public override void Init()
    {
        base.Init();
        //call enemydied when stuff dies
    }

    // if the id matches with the quest increment
    /*void EnemyDied(TypeEnemy enemy)
    {
        if (enemy.ID == this.EnemyID)
        {
            this.currentAmount++;
            Evaluate();
        }
    }*/
}
