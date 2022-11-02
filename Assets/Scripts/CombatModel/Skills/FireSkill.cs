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

    public void UseSkill(CombatUnit target, Stats userStats)
    {
        target.AddElementEffect(element);

        target.TakeDamage(userStats.attack * 0.5f);
    }
}
