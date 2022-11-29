using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CombatTest : MonoBehaviour
{
    CombatUnit unit;
    TMP_Text statsDisplay;

    public CombatUnit unitForBasicAttack;
    public CombatUnit targetForBasicAttack;


    private void Start()
    {
        if (TryGetComponent<TMP_Text>(out statsDisplay))
        {
            if (!TryGetComponent<CombatUnit>(out unit))
            {
                statsDisplay.text = "Unit Not Found";
            }
        }
    }

    private void Update()
    {
        //Updating Stats
        if (unit != null)
        {
            Stats stats = unit.currentStats;


            string elements = "";
            foreach(ElementEffect element in unit.elementEffects)
            {
                elements += element.ToString() + "\n";
            }
            string statuses = "";
            foreach (StatusEffect status in unit.statusEffects)
            {
                statuses += status.name + " " + status.duration + "\n";
            }
            string skils = "";
            foreach (Skill skill in unit.skills)
            {
                skils += skill.name + "\n";
            }

            string output = $@"
                Name: {gameObject.name}
                maxHP: {stats.maxHP} 
                HP: {unit.currentHP} 
                maxMP: {stats.maxMP} 
                MP: {unit.currentMP} 
                CD: {unit.currentMoveCD}
                attack: {stats.attack} 
                elements: {elements}
                statuses: {statuses}
                skills: {skils}
            ";

            statsDisplay.text = output;
        }
    }

    public void UseBasicAttack()
    {
        unitForBasicAttack.basicAttack.UseMove(targetForBasicAttack, unitForBasicAttack);
    }

    public void UseFireSkill()
    {
        unitForBasicAttack.skills[0].UseMove(targetForBasicAttack, unitForBasicAttack);
    }
    public void UseWaterSkill()
    {
        unitForBasicAttack.skills[1].UseMove(targetForBasicAttack, unitForBasicAttack);
    }
    public void UseRegularSkill()
    {
        unitForBasicAttack.skills[2].UseMove(targetForBasicAttack, unitForBasicAttack);
    }
}
