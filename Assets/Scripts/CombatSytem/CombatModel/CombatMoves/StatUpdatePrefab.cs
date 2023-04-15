using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatUpdatePrefab : MonoBehaviour
{
    public Stats newStats;
    public List<string> skillKeys;
    public CombatData alonzoData;

    public void SetCombatData()
    {
        alonzoData.baseStats = newStats;
        alonzoData.skillKeys = skillKeys;
    }

}
