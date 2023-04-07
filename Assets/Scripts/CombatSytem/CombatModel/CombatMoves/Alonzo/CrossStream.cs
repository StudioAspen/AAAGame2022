using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossStream : AlonzoSkill
{
    public CrossStream(AlonzoCombatUnit _owner = null)
    {
        name = "Cross Stream";
        owner = _owner;
        mpCost = 25f;
        targetAmount = 2;
    }

    public override void UseMove(List<CombatUnit> target, CombatUnit user)
    {
        //Double Strike
        StrikeFirstTarget(target[0], user);
        StrikeSecondTarget(target[1], user);

        owner.SetCharge(Element.NONE);
        user.ChangeMP(-mpCost);
    }
    public void StrikeFirstTarget(CombatUnit target, CombatUnit user)
    {
        owner.SetCharge(target.element);
        target.TakeDamage(user.currentStats.attack);
    }
    public void StrikeSecondTarget(CombatUnit target, CombatUnit user)
    {
        target.TakeDamage(user.currentStats.attack);
        target.AddElementStatus(new ElementStatus(owner.charge, owner));
    }
}
