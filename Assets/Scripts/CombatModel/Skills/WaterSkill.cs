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

    public override void UseSkill(CombatUnit target, Stats userStats)
    {
        Debug.Log("run water");
        target.AddElementEffect(element);

        target.TakeDamage(userStats.attack * 0.5f);
    }
}
