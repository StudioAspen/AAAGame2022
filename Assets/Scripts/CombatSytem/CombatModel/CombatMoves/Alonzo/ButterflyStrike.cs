using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyStrike : AlonzoSkill
{
    public ButterflyStrike(AlonzoCombatUnit _owner = null)
    {
        name = "Butterfly Strike";
        owner = _owner;
        mpCost = 20f;
    }

    public override void UseMove(CombatUnit target, CombatUnit user)
    {
        //Double Strike
        Strike(target, user);
        Strike(target, user);

        owner.SetCharge(Element.NONE);
        user.ChangeMP(-mpCost);
    }

    public void Strike(CombatUnit target, CombatUnit user)
    {
        target.ChangeHP(-user.currentStats.attack);
        target.AddElementStatus(new ElementStatus(owner.charge, owner));
    }
}
