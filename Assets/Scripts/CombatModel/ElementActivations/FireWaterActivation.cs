using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWaterActivation : ElementActivation
{
    public FireWaterActivation()
    {
        key.Add(ElementEffect.FIRE);
        key.Add(ElementEffect.WATER);
    }

    public override void ActivateElementEffect(CombatUnit target, Stats userStats)
    {
        Debug.Log("fire water activation");
        target.AddStatEffect(new AttackDownEffect(1));
        target.TakeDamage(userStats.attack * 2f);
    }
}
