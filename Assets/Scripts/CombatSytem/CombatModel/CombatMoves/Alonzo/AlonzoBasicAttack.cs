using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlonzoBasicAttack : BasicAttack
{
    public AlonzoCombatUnit owner;
    public AlonzoBasicAttack (AlonzoCombatUnit _owner = null)
    {
        name = "Basic Attack";
        owner = _owner;
        targetAmount = 1;
    }
    public override void UseMove(List<CombatUnit> target, CombatUnit user)
    {
        if (owner != null)
        {
            owner.SetCharge(target[0].element);
        }
        user.ChangeMP(mpGain);
    }
}
