using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSkill : Skill
{
    float damageMultiplier;
    public FireSkill()
    {
        name = "Fire Skill Move";
        element = ElementEffect.FIRE;
        damageMultiplier = 1.5f;
        mpCost = 10f;
    }

    public override void UseMove(CombatUnit target, CombatUnit user)
    {
        target.AddElementEffect(element, user.currentStats);
        target.TakeDamage(user.currentStats.attack * damageMultiplier);
        user.currentMP -= mpCost;
    }
}
