using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFireActivation : ElementActivation
{
    public FireFireActivation()
    {
        key.Add(ElementEffect.FIRE);
        key.Add(ElementEffect.FIRE);
    }

    public override void ActivateElementEffect(CombatUnit target, Stats userStats)
    {
        Debug.Log("fire fire activation");
        target.TakeDamage(userStats.attack * 3f);
    }
}
