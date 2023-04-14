using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpEffect : StatusEffect
{
    public float percentIncrease;
    public SpeedUpEffect(int _version)
    {
        version = Mathf.Clamp(_version, 0, 3);
        name = "Speed Up " + version.ToString();
        percentIncrease = version * 0.25f;
        durationBase = version * 2f;
        duration = durationBase;
        icon = GetIcon("Icons_for_daybreak_0");
        applySound = Resources.Load<AudioClip>("Debuffs/ChrisChavez_speedupbuff");
    }
    override public Stats ApplyEffect(Stats currentStats)
    {
        currentStats.speed *= (1 + percentIncrease);
        return currentStats;
    }
    public override void ApplyUpdateEffect(CombatUnit owner) { }
}
