using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSkill : Skill
{
    // Start is called before the first frame update
    void Start()
    {
        name = "Fire Skill Move";
        element = ElementEffect.FIRE;
    }

    public override void UseSkill(CombatUnit target, Stats userStats)
    {
        Debug.Log("run water");
        target.AddElementEffect(element);

        target.TakeDamage(userStats.attack * 1.5f);
    }
}
