using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDogCombatUnit : CombatUnit
{
    override public void InitalizeBaseCombatUnit(CombatData combatData)
    {
        //Setting stats and moves from overworld
        baseStats = combatData.baseStats;
        //Assigning Skills
        skills.Clear();
        foreach (string skillKey in combatData.skillKeys)
        {
            FireDogSkill currentSkill = FireDogSkill.GetSkill(skillKey);
            skills.Add(currentSkill);
        }
    }
}
