using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CombatData", order = 1)]
public class CombatData : ScriptableObject
{
    //Input Values
    public Stats baseStats;
    public List<string> skillKeys;
    public GameObject combatPrefab;
}