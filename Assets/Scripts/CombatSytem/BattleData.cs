using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BattleData", order = 1)]
public class BattleData : ScriptableObject
{
    public List<CombatData> players;
    public List<CombatData> enemies;
    public UnityEvent afterCombat;
}
