using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlonzoCombatUnit : CombatUnit
{
    public Element charge = Element.NONE;
    public AlonzoCombatData combatData;
    private void Start()
    {
        InitalizeCombatUnit(combatData);
    }
    //initalize combat unit with data
    override public void InitalizeCombatUnit(AlonzoCombatData _combatData)
    {
        //Setting stats and moves from overworld
        baseStats = _combatData.baseStats;
        basicAttack = _combatData.alonzoBasicAttack;
        skills.Clear();
        foreach(AlonzoSkill skill in _combatData.alonzoSkills)
        {
            skills.Add(skill); 
        }

        //Initalized Values for current combat stats
        currentHP = baseStats.maxHP;
        currentMP = 0f;
        currentMoveCD = baseStats.moveCD;
        currentStats = new Stats(baseStats);
        
    }

    public void SetCharge(Element element)
    {
        charge = element;
    }
}
