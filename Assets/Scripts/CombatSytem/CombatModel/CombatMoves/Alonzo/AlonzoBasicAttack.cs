using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlonzoBasicAttack : BasicAttack
{
    AlonzoCombatUnit alonzo;
    public AlonzoBasicAttack (AlonzoCombatUnit _alonzo = null)
    {
        name = "Basic Attack";
        alonzo = _alonzo;
    }
    public override void UseMove(CombatUnit target, CombatUnit user)
    {
        if (alonzo != null)
        {
            alonzo.SetCharge(target.element);
        }
        user.ChangeMP(mpGain);
    }
}
