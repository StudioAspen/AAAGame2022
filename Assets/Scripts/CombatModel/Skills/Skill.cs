using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Skill
{
    public string name;
    public ElementEffect element;

    abstract public void UseSkill(CombatUnit target, Stats userStats);
}
