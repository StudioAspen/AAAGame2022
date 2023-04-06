using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CombatMove
{
    public string name;
    public int targetAmount; // -1 is all available targets

    public abstract void UseMove(List<CombatUnit> target, CombatUnit user);
}
