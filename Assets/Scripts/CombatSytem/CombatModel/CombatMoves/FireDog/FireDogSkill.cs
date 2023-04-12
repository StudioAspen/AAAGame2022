using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class FireDogSkill : Skill
{
    enum FireDogSkills { 
        FIREBITE
    }

    static Dictionary<string, FireDogSkills> dictionary = new Dictionary<string, FireDogSkills>()
    {
        { "Fire Dog Bite", FireDogSkills.FIREBITE}
    };

    protected AnimatorOverrideController overrideController =
        Resources.Load<AnimatorOverrideController>("Animations/CombatSystem/FireBoar/FireBoarOverride");

    static public FireDogSkill GetSkill(string key)
    {
        FireDogSkill output = new FireDogBite();
        switch (dictionary[key]) {
            case FireDogSkills.FIREBITE:
                output = new FireDogBite();
                break;
        }

        return output;
    }
}
