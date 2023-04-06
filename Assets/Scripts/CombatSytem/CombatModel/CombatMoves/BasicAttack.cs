using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : CombatMove
{
    protected float mpGain;
    public BasicAttack()
    {
        name = "Basic Attack";
        mpGain = 30f;
        targetAmount = 1;
    }
    public override void UseMove(List<CombatUnit> target, CombatUnit user)
    {
        user.ChangeMP(mpGain);
    }
}
