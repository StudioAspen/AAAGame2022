using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats
{
    public float maxHP;
    public float HP;
    public float maxMP;
    public float MP;
    public float moveCDBase;
    public float moveCD;
    public float mpGain;
    public float attack;

    //Constructor that sets current equal to max stats
    public Stats(float _maxHP, float _maxMP, float _moveCDBase, float _mpGain, float _attack)
    {
        maxHP = _maxHP;
        HP = _maxHP;
        maxMP = _maxMP;
        MP = _maxMP;
        moveCDBase = _moveCDBase;
        moveCD = _moveCDBase;
        mpGain = _mpGain;
        attack = _attack;
    }

    //Copy Constructor
    public Stats(Stats stats)
    {
        maxHP = stats.maxHP;
        HP = stats.HP;
        maxMP = stats.maxMP;
        MP = stats.MP;
        moveCDBase = stats.moveCDBase;
        moveCD = stats.moveCD;
        mpGain = stats.mpGain;
        attack = stats.attack;
    }
}
