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
    }
    public override void UseMove(CombatUnit target, CombatUnit user)
    {
        if (owner != null)
        {
            owner.SetCharge(target.element);
        }
        user.ChangeMP(mpGain);
    }
}
