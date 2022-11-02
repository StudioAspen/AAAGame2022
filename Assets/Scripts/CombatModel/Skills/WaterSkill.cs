using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSkill : Skill
{

    public WaterSkill()
    {
        name = "Water Skill Move";
        element = ElementEffect.WATER;
    }
    private void Awake()
    {
        name = "Water Skill Move";
        element = ElementEffect.WATER;
    }

    public override void UseSkill(CombatUnit target, Stats userStats)
    {
        target.AddElementEffect(element, userStats);

        target.TakeDamage(userStats.attack * 0.5f);
    }
}
