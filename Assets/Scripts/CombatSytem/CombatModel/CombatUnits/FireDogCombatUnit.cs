using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDogCombatUnit : CombatUnit
{
    FireDogCombatData combatData;
    // Start is called before the first frame update
    private void Awake()
    {
        combatData = GetComponent<FireDogCombatData>();
        InitalizeCombatUnit(combatData);
    }
}
