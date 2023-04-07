using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Stats
{
    const float speedToSec = 5f;
    const float baseSpeed = 100f;
    public float maxHP;
    public float maxMP;
    public float speed;
    public float mpGain;
    public float attack;
    public float defence;

    //Constructor that sets current equal to max stats with arbitrary stats
    public Stats(float _maxHP = 100, float _maxMP = 100, float _speed = 10, float _mpGain = 10, float _attack = 10, float _defence = 10)
    {
        maxHP = _maxHP;
        maxMP = _maxMP;
        speed = _speed;
        mpGain = _mpGain;
        attack = _attack;
        defence = _defence;
    }

    //Copy Constructor
    public Stats(Stats stats)
    {
        maxHP = stats.maxHP;
        maxMP = stats.maxMP;
        speed = stats.speed;
        mpGain = stats.mpGain;
        attack = stats.attack;
        defence = stats.defence;
    }
    public void RandomizeStats()
    {
        float maxHPQuart = maxHP / 4;
        float maxMPQuart = maxMP / 4;
        float speedQuart = speed / 4;
        float mpGainQuart = mpGain / 4;
        float attackQuart = attack / 4;
        float defenceQuart = attack / 4;

        maxHP += Random.Range(-maxHPQuart, maxHPQuart);
        maxMP += Random.Range(-maxMPQuart, maxMPQuart);
        speed += Random.Range(-speedQuart, speedQuart);
        mpGain += Random.Range(-mpGainQuart, mpGainQuart);
        attack += Random.Range(-attackQuart, attackQuart);
        defence += Random.Range(-defenceQuart, defenceQuart);
    }
    public void Add(Stats stats)
    {
        maxHP += stats.maxHP;
        maxMP += stats.maxMP;
        speed += stats.speed;
        mpGain += stats.mpGain;
        attack += stats.attack;
        defence += stats.defence;
    }
    public float SpeedToSec()
    {
        return speedToSec * (baseSpeed / speed);
    }
}
