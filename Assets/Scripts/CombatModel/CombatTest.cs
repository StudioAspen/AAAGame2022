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
                statuses += status.name + "\n";
            }
            string skils = "";
            foreach (Skill skill in unit.skills)
            {
                skils += skill.name + "\n";
            }

            string output = $@"
                maxHP: {stats.maxHP} 
                HP: {stats.HP} 
                maxMP: {stats.maxMP} 
                MP: {stats.MP} 
                mpGain: {stats.mpGain} 
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
        unitForBasicAttack.BasicAttack(targetForBasicAttack);
    }

    public void UseFireSkill()
    {
        unitForBasicAttack.skills[0].UseSkill(targetForBasicAttack, unitForBasicAttack.currentStats);
    }
    public void UseWaterSkill()
    {
        unitForBasicAttack.skills[1].UseSkill(targetForBasicAttack, unitForBasicAttack.currentStats);
    }
}
