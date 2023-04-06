using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyStrike : AlonzoSkill
{
    public ButterflyStrike(AlonzoCombatUnit _owner = null)
    {
        name = "Butterfly Strike";
        owner = _owner;
        mpCost = 25f;
        targetAmount = 1;
    }

    public override void UseMove(List<CombatUnit> target, CombatUnit user)
    {
        //Double Strike
        Strike(target[0], user);
        Strike(target[0], user);

        owner.SetCharge(Element.NONE);
        user.ChangeMP(-mpCost);
    }

    public void Strike(CombatUnit target, CombatUnit user)
    {
        target.TakeDamage(user.currentStats.attack);
        target.AddElementStatus(new ElementStatus(owner.charge, owner));
    }
}
