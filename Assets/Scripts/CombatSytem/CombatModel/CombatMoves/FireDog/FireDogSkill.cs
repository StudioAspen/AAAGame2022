using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class FireDogSkill : Skill
{
    static Dictionary<string, FireDogSkill> dictionary = new Dictionary<string, FireDogSkill>()
    {
        { "Fire Dog Bite", new FireDogBite()}
    };
    public AlonzoCombatUnit owner;

    static public FireDogSkill GetSkill(string key)
    {
        return dictionary[key];
    }
}
