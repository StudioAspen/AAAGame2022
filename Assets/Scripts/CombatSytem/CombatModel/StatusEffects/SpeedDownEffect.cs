using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedDownEffect : StatusEffect
{
    public float percentDecrease;
    public SpeedDownEffect(int _version)
    {
        version = Mathf.Clamp(_version, 0, 3);
        name = "Speed Down " + version.ToString();
        percentDecrease = version * 0.25f;
        durationBase = version * 2f;
        duration = durationBase;
        icon = GetIcon("Icons_for_daybreak_1");
        applySound = Resources.Load<AudioClip>("");
    }
    override public Stats ApplyEffect(Stats currentStats)
    {
        currentStats.speed *= (1 - percentDecrease);
        return currentStats;
    }
    public override void ApplyUpdateEffect(CombatUnit owner) { }
}
