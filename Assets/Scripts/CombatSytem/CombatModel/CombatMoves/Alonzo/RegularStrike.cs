using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularStrike : AlonzoSkill
{
    public RegularStrike(AlonzoCombatUnit _owner = null)
    {
        name = "Regular Strike";
        owner = _owner;
        mpCost = 20f;
        targetAmount = 1;
    }

    public override void UseMove(List<CombatUnit> target, CombatUnit user)
    {
        target[0].TakeDamage(user.currentStats.attack);
        target[0].AddElementStatus(new ElementStatus(owner.charge, owner));

        owner.SetCharge(Element.NONE);
        user.ChangeMP(-mpCost);
    }
}
