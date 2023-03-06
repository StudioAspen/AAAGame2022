using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Skill : CombatMove
{
    public float mpCost;

    public bool CanUse(CombatUnit user)
    {
        return user.currentMP >= mpCost;
    }
}
