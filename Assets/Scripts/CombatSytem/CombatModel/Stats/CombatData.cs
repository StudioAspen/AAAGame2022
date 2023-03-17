using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class CombatData : MonoBehaviour
{
    public Stats baseStats = new Stats(50);
    public BasicAttack basicAttack = new BasicAttack();
    public List<Skill> skills = new List<Skill>();
}