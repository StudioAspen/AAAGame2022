using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class CynthiSkill : Skill
{
    static Dictionary<string, CynthiSkill> dictionary = new Dictionary<string, CynthiSkill>()
    {
        {"Cynthi Strike", new CynthiStrike() }
    };
    protected AnimatorOverrideController overrideController =
        Resources.Load<AnimatorOverrideController>("Animations/CombatSystem/Cynthi/CynthiOverride");

    static public CynthiSkill GetSkill(string key)
    {
        return dictionary[key];
    }
}
