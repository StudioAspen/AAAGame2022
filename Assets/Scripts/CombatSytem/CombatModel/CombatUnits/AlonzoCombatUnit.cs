using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlonzoCombatUnit : CombatUnit
{
    public Element charge = Element.NONE;
    public CombatData combatData; //Referenced scriptable object
    //initalize combat unit with data
    override public void InitalizeBaseCombatUnit(CombatData combatData)
    {
        //Setting stats and moves from overworld
        baseStats = combatData.baseStats;

        //Assgining Basic Attack
        AlonzoBasicAttack holder = new AlonzoBasicAttack();
        holder.owner = this;
        basicAttack = holder;

        //Assigning Skills
        skills.Clear();
        foreach (string skillKey in combatData.skillKeys)
        {
            AlonzoSkill currentSkill = AlonzoSkill.GetSkill(skillKey);
            currentSkill.owner = this;
            skills.Add(currentSkill);
        }
    }

    override public void StartAttack()
    {
        animator.SetTrigger("StartAttack");
    }
    public void SetCharge(Element element)
    {
        charge = element;
    }
}
