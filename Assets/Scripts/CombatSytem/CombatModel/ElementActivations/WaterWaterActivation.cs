using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterWaterActivation : ElementActivation
{
    public WaterWaterActivation()
    {
        key.Add(ElementEffect.WATER);
        key.Add(ElementEffect.WATER);
    }

    public override void ActivateElementEffect(CombatUnit target, Stats userStats)
    {
        Debug.Log("WAter activation");
        target.AddStatEffect(new AttackDownEffect(3));
    }
}
