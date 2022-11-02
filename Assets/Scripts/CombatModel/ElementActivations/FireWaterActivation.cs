using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWaterActivation : ElementActivation
{
    AttackDownEffect attackDownEffect;
    public FireWaterActivation()
    {
        key.Add(ElementEffect.FIRE);
        key.Add(ElementEffect.WATER);

        attackDownEffect = new AttackDownEffect(0.25f);
    }

    public override void ActivateElementEffect(CombatUnit target, Stats userStats)
    {
        Debug.Log("fire water activation");
        target.AddStatEffect(attackDownEffect);
        target.TakeDamage(userStats.attack * 2f);
    }
}
