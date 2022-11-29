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

    public override void UseMove(CombatUnit target, CombatUnit user)
    {
        target.ChangeHP(-user.currentStats.attack);
        user.currentMP -= mpCost;
    }
}
