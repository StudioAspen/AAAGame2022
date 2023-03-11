using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Stats
{
    public float maxHP;
    public float maxMP;
    public float moveCD;
    public float attack;

    //Constructor that sets current equal to max stats with arbitrary stats
    public Stats(float _maxHP = 100, float _maxMP = 100, float _moveCD = 10, float _attack = 10)
    {
        maxHP = _maxHP;
        maxMP = _maxMP;
        moveCD = _moveCD;
        attack = _attack;
    }

    //Copy Constructor
    public Stats(Stats stats)
    {
        maxHP = stats.maxHP;
        maxMP = stats.maxMP;
        moveCD = stats.moveCD;
        attack = stats.attack;
    }
    public void RandomizeStats()
    {
        float maxHPQuart = maxHP / 4;
        float maxMPQuart = maxMP / 4;
        float moveCDQuart = moveCD / 4;
        float attackQuart = attack / 4;

        maxHP += Random.Range(-maxHPQuart, maxHPQuart);
        maxMP += Random.Range(-maxMPQuart, maxMPQuart);
        moveCD += Random.Range(-moveCDQuart, moveCDQuart);
        attack += Random.Range(-attackQuart, attackQuart);
    }
}
