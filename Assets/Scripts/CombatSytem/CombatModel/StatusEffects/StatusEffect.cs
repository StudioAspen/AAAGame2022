using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatusEffect
{
    public string name;
    public float duration;
    public float durationBase;
    public bool limited;
    public int version;
    public Sprite icon;
    public Sprite[] spriteIcons = Resources.LoadAll<Sprite>("Sprites/Icons_for_daybreak");
    public abstract Stats ApplyEffect(Stats currentStats);
    public abstract void ApplyUpdateEffect(CombatUnit owner);
    protected Sprite GetIcon(string iconName)
    {
        Sprite output = null;
        foreach(Sprite sprite in spriteIcons)
        {
            if(sprite.name == iconName)
            {
                output = sprite;
            }
        }
        return output;
    }
}
