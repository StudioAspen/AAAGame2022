using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDownEffect : StatusEffect {
    float percentDecrease;
    int version;

    public AttackDownEffect(int _version)
    {
        version = Mathf.Clamp(_version, 0, 3);
        name = "Attack Down " + version.ToString();
        percentDecrease = version * 0.25f;
        duration = version * 2f;
    }

    public override Stats ApplyEffect(Stats currentStats)
    {
        currentStats.attack *= (1 - percentDecrease);
        return currentStats;
    }
}
