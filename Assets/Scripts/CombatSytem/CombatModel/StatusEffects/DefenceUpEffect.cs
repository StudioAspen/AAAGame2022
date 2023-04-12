using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenceUpEffect : StatusEffect
{
    public float percentIncrease;
    public DefenceUpEffect(int _version)
    {
        version = Mathf.Clamp(_version, 0, 3);
        name = "Defence Up " + version.ToString();
        percentIncrease = version * 0.25f;
        durationBase = version * 2f;
        duration = durationBase;
        icon = GetIcon("Icons_for_daybreak_2");
    }
    override public Stats ApplyEffect(Stats currentStats)
    {
        currentStats.defence *= (1 + percentIncrease);
        return currentStats;
    }
    public override void ApplyUpdateEffect(CombatUnit owner) { }
}
