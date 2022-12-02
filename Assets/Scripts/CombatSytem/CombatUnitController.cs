using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatUnitController : MonoBehaviour
{
    public CombatUnit combatUnit;
    public AssignStatBars assignStatBars;
    // Start is called before the first frame update
    void Start()
    {
        combatUnit = GetComponent<CombatUnit>();
    }

    // Update is called once per frame
    void Update()
    {
        assignStatBars.UpdateStatBars(combatUnit);
    }
}
