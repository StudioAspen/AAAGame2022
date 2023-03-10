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
        float maxHPQuart = this.maxHP / 4;
        float maxMPQuart = this.maxMP / 4;
        float moveCDQuart = this.moveCD / 4;
        float attackQuart = this.attack / 4;

        this.maxHP += Random.Range(-maxHPQuart, maxHPQuart);
        this.maxMP += Random.Range(-maxMPQuart, maxMPQuart);
        this.moveCD += Random.Range(-moveCDQuart, moveCDQuart);
        this.attack += Random.Range(-attackQuart, attackQuart);
    }
}
