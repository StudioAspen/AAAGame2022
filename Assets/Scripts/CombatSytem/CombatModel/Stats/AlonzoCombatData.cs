using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/AlonzoCombatData", order = 1)]
public class AlonzoCombatData : ScriptableObject
{
    //Other Data
    Dictionary<string, AlonzoSkill> allAlonzoSkills = new Dictionary<string, AlonzoSkill>();

    //Manual Inputs
    public List<string> skillKeys = new List<string>();
    public float maxHP;
    public float maxMP;
    public float moveCD;
    public float attack;

    //Actual used values
    public Stats baseStats;
    public List<AlonzoSkill> alonzoSkills = new List<AlonzoSkill>();
    public AlonzoBasicAttack alonzoBasicAttack = new AlonzoBasicAttack();
    public AlonzoCombatData()
    {
        //Initalize all skills in dictionary
        allAlonzoSkills.Add("Regular Strike", new RegularStrike());
    }
    public void AddSkill(AlonzoSkill alonzoSkill)
    {
        if(!alonzoSkills.Contains(alonzoSkill))
        {
            alonzoSkills.Add(alonzoSkill);
        }
    }
    [ContextMenu("SyncDataManualToHidden")]
    public void SyncDataManualToHidden()
    {
        //Setting Hidden stats
        baseStats = new Stats(maxHP, maxMP, moveCD, attack);

        //Initalizing all skills from key list
        alonzoSkills.Clear();
        foreach (string skillKey in skillKeys)
        {
            AddSkill(allAlonzoSkills[skillKey]);
        }
    }
    [ContextMenu("SyncDataHiddenToManual")]
    public void SyncDataHiddenToManual()
    {
        //Setting manual stats
        maxHP = baseStats.maxHP;
        maxMP = baseStats.maxMP;
        moveCD = baseStats.moveCD;
        attack = baseStats.attack;

        //Setting keys
        skillKeys.Clear();
        foreach (AlonzoSkill skill in alonzoSkills)
        {
            foreach (KeyValuePair<string, AlonzoSkill> keyValuePair in allAlonzoSkills)
            {
                if(keyValuePair.Value == skill)
                {
                    skillKeys.Add(keyValuePair.Key);
                }
            }
        }
    }
    public void InitalizeDefaultValues()
    {
        baseStats = new Stats();
        baseStats.RandomizeStats();
        alonzoSkills.Clear();
        alonzoSkills.Add(new RegularStrike());
    }
}