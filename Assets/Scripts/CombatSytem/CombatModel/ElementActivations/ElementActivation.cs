using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class ElementActivation
{
    public List<ElementEffect> key = new List<ElementEffect>();

    abstract public void ActivateElementEffect(CombatUnit target, Stats userStats);
}
