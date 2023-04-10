using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : CombatMove
{
    protected float mpGain;
    protected AnimatorOverrideController overrideController =
        Resources.Load<AnimatorOverrideController>("Animations/CombatSystem/Alonzo/AlonzoAttackOverride");
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
