using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSkill : Skill
{
    float damageMultiplier;
    public WaterSkill()
    {
        name = "Water Skill Move";
        element = ElementEffect.WATER;
        damageMultiplier = 0.5f;
        mpCost = 10f;
    }

    public override void UseMove(CombatUnit target, Stats userStats)
    {
        target.AddElementEffect(element, userStats);
        target.TakeDamage(userStats.attack * damageMultiplier);
        userStats.MP -= mpCost;
    }
}
