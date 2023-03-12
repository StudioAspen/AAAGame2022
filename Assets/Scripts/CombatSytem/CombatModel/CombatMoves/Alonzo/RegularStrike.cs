using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularStrike : AlonzoSkill
{
    public RegularStrike(AlonzoCombatUnit _owner = null)
    {
        name = "Regular Strike";
        owner = _owner;
        mpCost = 10f;
    }

    public override void UseMove(CombatUnit target, CombatUnit user)
    {
        target.ChangeHP(-user.currentStats.attack);
        target.AddElementStatus(new ElementStatus(owner.charge, owner));
        owner.SetCharge(Element.NONE);
        user.ChangeMP(-mpCost);
    }
}
