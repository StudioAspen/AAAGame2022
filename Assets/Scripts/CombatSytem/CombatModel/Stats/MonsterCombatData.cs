using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCombatData
{
    public Stats baseStats = new Stats();
    public List<Skill> skills = new List<Skill>();


    public MonsterCombatData()
    {
        skills.Add(new FireBite());
        baseStats.RandomizeStats(); // Currently randomized for testing
    }
}
