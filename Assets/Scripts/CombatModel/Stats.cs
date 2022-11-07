using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats
{
    public float maxHP;
    public float HP;
    public float maxMP;
    public float MP;
    public float mpGain;
    public float attack;

    public Stats(float _maxHP, float _HP, float _maxMP, float _MP, float _mpGain, float _attack)
    {
        maxHP = _maxHP;
        HP = _HP;
        maxMP = _maxMP;
        MP = _MP;
        mpGain = _mpGain;
        attack = _attack;
    }
    public Stats(Stats stats)
    {
        maxHP = stats.maxHP;
        HP = stats.HP;
        maxMP = stats.maxMP;
        MP = stats.MP;
        mpGain = stats.mpGain;
        attack = stats.attack;
    }
}
