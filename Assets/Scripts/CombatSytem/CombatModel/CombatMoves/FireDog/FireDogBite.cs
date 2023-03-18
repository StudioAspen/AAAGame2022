using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDogBite : FireDogSkill
{
    public FireDogBite()
    {
        name = "Fire Bite";
        mpCost = 0f;
    }

    public override void UseMove(CombatUnit target, CombatUnit user)
    {
        //target.AddElementEffect(element, user.currentStats);
        target.ChangeHP(-(user.currentStats.attack*0.5f));
        target.ChangeMP(-(user.currentStats.attack * 0.25f));
    }
    
}
