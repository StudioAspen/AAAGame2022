using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularStrike : AlonzoSkill
{
    public RegularStrike(AlonzoCombatUnit _alonzo = null)
    {
        name = "Regular Strike";
        alonzo = _alonzo;
        mpCost = 10f;
    }

    public override void UseMove(CombatUnit target, CombatUnit user)
    {
        target.ChangeHP(-user.currentStats.attack);
        target.AddElementStatus(new ElementStatus(alonzo.charge, alonzo));
        alonzo.SetCharge(Element.NONE);
        user.ChangeMP(-mpCost);
    }
}
