using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDownEffect : StatusEffect {
    float percentDecrease;
    int version;

    public AttackDownEffect(int _version)
    {
        name = "Attack Down";
        version = _version; //Should be max 3
        percentDecrease = version * 0.25f;
    }

    public override Stats ApplyEffect(Stats currentStats)
    {
        currentStats.attack *= (1 - percentDecrease);
        return currentStats;
    }
}
