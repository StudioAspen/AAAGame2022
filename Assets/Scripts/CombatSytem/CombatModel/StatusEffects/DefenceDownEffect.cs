using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenceDownEffect : StatusEffect
{
    public float percentDecrease;
    public DefenceDownEffect(int _version)
    {
        version = Mathf.Clamp(_version, 0, 3);
        name = "Defence Down " + version.ToString();
        percentDecrease = version * 0.25f;
        durationBase = version * 2f;
        duration = durationBase;
        icon = GetIcon("Icons_for_daybreak_3");
    }
    override public Stats ApplyEffect(Stats currentStats)
    {
        currentStats.defence *= (1 - percentDecrease);
        return currentStats;
    }
    public override void ApplyUpdateEffect(CombatUnit owner) { }
}
