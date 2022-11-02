using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSkill : Skill
{
    public FireSkill()
    {
        name = "Fire Skill Move";
        element = ElementEffect.FIRE;
    }

    public override void UseSkill(CombatUnit target, Stats userStats)
    {
        target.AddElementEffect(element, userStats);

        target.TakeDamage(userStats.attack * 1.5f);
    }
}
