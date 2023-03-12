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
        duration = version * 2f;
        icon = Resources.Load<Sprite>("Sprites/DebuffIcons/redSquareArrow");
    }
    override public Stats ApplyEffect(Stats currentStats)
    {
        currentStats.attack *= (1 + percentIncrease);
        return currentStats;
    }
}
