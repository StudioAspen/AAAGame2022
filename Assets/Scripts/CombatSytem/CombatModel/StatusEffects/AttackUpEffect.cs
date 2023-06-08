using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUpEffect : StatusEffect
{
    public float percentIncrease;
    public AttackUpEffect(int _version)
    {
        version = Mathf.Clamp(_version, 0, 3);
        name = "Attack Up " + version.ToString();
        percentIncrease = version * 0.25f;
        durationBase = version * 2f;
        duration = durationBase;
        icon = GetIcon("Icons_for_daybreak_5");
        applySound = Resources.Load<AudioClip>("Debuffs/ChrisChavez_attackUPbuff");
    }
    override public Stats ApplyEffect(Stats currentStats)
    {
        currentStats.attack *= (1 + percentIncrease);
        return currentStats;
    }
    public override void ApplyUpdateEffect(CombatUnit owner) { }
}
