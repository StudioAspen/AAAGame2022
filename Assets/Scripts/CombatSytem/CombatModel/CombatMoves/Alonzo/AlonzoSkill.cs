using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class AlonzoSkill : Skill
{
    static Dictionary<string, AlonzoSkill> dictionary = new Dictionary<string, AlonzoSkill>()
    {
        {"Regular Strike", new RegularStrike() }
    };
    public AlonzoCombatUnit owner;

    static public AlonzoSkill GetSkill(string key)
    {
        return dictionary[key];
    }
}
