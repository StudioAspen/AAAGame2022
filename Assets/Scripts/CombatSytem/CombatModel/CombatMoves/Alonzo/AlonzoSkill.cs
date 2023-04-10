using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class AlonzoSkill : Skill
{
    static Dictionary<string, AlonzoSkill> dictionary = new Dictionary<string, AlonzoSkill>()
    {
        {"Regular Strike", new RegularStrike() },
        {"Butterfly Strike", new ButterflyStrike() },
        {"Cross Stream", new CrossStream() },
        {"NightShade Aura", new NightShadeAura() }
    };
    protected AnimatorOverrideController overrideController =
        Resources.Load<AnimatorOverrideController>("Animations/CombatSystem/Alonzo/AlonzoAttackOverride");
    public AlonzoCombatUnit owner;

    static public AlonzoSkill GetSkill(string key)
    {
        return dictionary[key];
    }
}
