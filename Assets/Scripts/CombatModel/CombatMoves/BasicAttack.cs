using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : CombatMove
{
    float mpGain;
    public BasicAttack()
    {
        name = "Basic Attack";
        mpGain = 10f;
    }
    public override void UseMove(CombatUnit target, CombatUnit user)
    {
        user.ChangeHP(mpGain);
    }
}
