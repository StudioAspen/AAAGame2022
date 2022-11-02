using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterWaterActivation : ElementActivation
{
    AttackDownEffect attackDownEffect;
    public WaterWaterActivation()
    {
        key.Add(ElementEffect.WATER);
        key.Add(ElementEffect.WATER);

        attackDownEffect = new AttackDownEffect(0.5f);
    }

    public override void ActivateElementEffect(CombatUnit target, Stats userStats)
    {
        Debug.Log("WAter activation");
        target.AddStatEffect(attackDownEffect);
    }
}
