using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDogCombatData : CombatData
{
    private void Start()
    {
        skills.Add(new FireBite());
        baseStats.RandomizeStats(); // Currently randomized for testing
    }
}
