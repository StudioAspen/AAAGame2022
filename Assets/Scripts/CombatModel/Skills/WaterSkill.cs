using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSkill : Skill
{
    // Start is called before the first frame update
    void Start()
    {
        name = "Water Skill Move";
        element = ElementEffect.WATER;
    }

    public void UseSkill(CombatUnit target, Stats userStats)
    {
        target.AddElementEffect(element);

        target.TakeDamage(userStats.attack * 0.5f);
    }
}
