using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CynthiCombatUnit : CombatUnit
{
    override public void InitalizeBaseCombatUnit(CombatData combatData)
    {
        //Setting stats and moves from overworld
        baseStats = combatData.baseStats;
        //Assigning Skills
        skills.Clear();
        foreach (string skillKey in combatData.skillKeys)
        {
            CynthiSkill currentSkill = CynthiSkill.GetSkill(skillKey);
            skills.Add(currentSkill);
        }
    }
    override public void StartAttack()
    {
        animator.SetTrigger("StartAttack");
    }
}
