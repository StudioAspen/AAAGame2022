using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CombatMove
{
    public string name;
    public abstract void UseMove(CombatUnit target, CombatUnit user);
}
