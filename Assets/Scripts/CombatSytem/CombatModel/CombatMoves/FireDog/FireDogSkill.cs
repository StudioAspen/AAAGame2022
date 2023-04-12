using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class FireDogSkill : Skill
{
    static Dictionary<string, FireDogSkill> dictionary = new Dictionary<string, FireDogSkill>()
    {
        { "Fire Dog Bite", new FireDogBite()}
    };

    protected AnimatorOverrideController overrideController =
        Resources.Load<AnimatorOverrideController>("Animations/CombatSystem/FireBoar/FireBoarOverride");

    static public FireDogSkill GetSkill(string key)
    {
        return dictionary[key];
    }
}
