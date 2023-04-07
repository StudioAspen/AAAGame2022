using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDogBite : FireDogSkill
{
    public FireDogBite()
    {
        name = "Fire Bite";
        mpCost = 0f;
        targetAmount = 1;
    }

    public override void UseMove(List<CombatUnit> target, CombatUnit user)
    {
        target[0].TakeDamage(user.currentStats.attack);
        target[0].ChangeMP(-(user.currentStats.attack));
    }
    
}
