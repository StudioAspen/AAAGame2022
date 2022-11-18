using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularSkill : Skill
{
    public RegularSkill()
    {
        name = "Regular Skill Move";
        mpCost = 10f;
    }

    public override void UseMove(CombatUnit target, Stats userStats)
    {
        target.TakeDamage(userStats.attack);
        userStats.MP -= mpCost;
    }
}
