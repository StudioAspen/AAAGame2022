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

    public override void UseSkill(CombatUnit target, Stats userStats)
    {
        target.AddElementEffect(element, userStats);
        target.TakeDamage(userStats.attack * damageMultiplier);
        userStats.MP -= mpCost;
    }
}
