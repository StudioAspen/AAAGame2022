using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats
{
    public float maxHP;
    public float maxMP;
    public float moveCD;
    public float attack;

    public Stats()
    {
        //Arbitrary initalization for testing
        maxHP = 100;
        maxMP = 100;
        moveCD = 10;
        attack = 10;
    }
    //Constructor that sets current equal to max stats
    public Stats(float _maxHP, float _maxMP, float _moveCD, float _attack)
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
