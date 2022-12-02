using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatData
{
    public Stats baseStats;
    public BasicAttack basicAttack;
    public List<Skill> skills;

    public CombatData(bool isPlayer)
    {
        baseStats = new Stats();
        basicAttack = new BasicAttack();
        skills = new List<Skill>();

        ///Curently for testing
        if (isPlayer)
        {
            skills.Add(new FireSkill());
            skills.Add(new WaterSkill());
        }
        else
        {
            skills.Add(new FireBite());
        }
        skills.Add(new RegularSkill());
        baseStats.RandomizeStats();
        /////////////////////////////////////////
    }

    public CombatData(Stats _baseStats, BasicAttack _basicAttack, List<Skill> _skills)
    {
        baseStats = _baseStats;
        basicAttack = _basicAttack;
        skills = _skills;

    }
}
