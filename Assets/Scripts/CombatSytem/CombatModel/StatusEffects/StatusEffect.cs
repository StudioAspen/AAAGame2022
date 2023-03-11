using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatusEffect
{
    public string name;
    public float duration;
    public bool limited;
    public int version;
    public Sprite icon;
    public abstract Stats ApplyEffect(Stats currentStats);
}
