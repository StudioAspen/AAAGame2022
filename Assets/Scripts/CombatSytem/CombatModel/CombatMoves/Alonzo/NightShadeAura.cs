using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightShadeAura : AlonzoSkill
{
    public NightShadeAura(AlonzoCombatUnit _owner = null)
    {
        name = "NightSade Aura";
        owner = _owner;
        mpCost = 30f;
        targetAmount = -1;
    }

    public override void UseMove(List<CombatUnit> targets, CombatUnit user)
    {
        foreach(CombatUnit target in targets)
        {
            target.TakeDamage(-user.currentStats.attack);
        }
        user.ChangeMP(-mpCost);
    }
}
