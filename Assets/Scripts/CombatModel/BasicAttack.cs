using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : CombatMove
{
    public BasicAttack()
    {
        name = "Basic Attack";
    }
    public override void UseMove(CombatUnit target, Stats userStats)
    {
        userStats.MP += userStats.mpGain;
    }
}
