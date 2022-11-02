using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatUnit : MonoBehaviour
{
    //Stats of unit
    private Stats baseStats;
    public Stats currentStats;

    //Available Skills on unit
    public Skill[] skillSet;

    //Effects on unit
    public List<StatusEffect> statusEffects = new List<StatusEffect>();
    public List<ElementEffect> elementEffects;

    float moveCDBase;
    float moveCD;

    //For element activation
    ElementSystem elementSystem;

    void Start()
    {
        //TESTING intialized values
        baseStats = new Stats(100, 100, 100, 0, 10, 10);

        //Initalized Values
        moveCD = moveCDBase;
        currentStats = new Stats(baseStats);

        elementSystem = FindObjectOfType<ElementSystem>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void BasicAttack(CombatUnit target) {
        currentStats.MP += currentStats.mpGain;
    }
    public void TakeDamage(float amount) {
        currentStats.HP -= amount;
    }
    public void AddStatEffect(StatusEffect statusEffect) {
        statusEffects.Add(statusEffect);
        ApplyAllStatusEffects();
    }
    public void ApplyAllStatusEffects() {
        //Recalculating stats
        currentStats = new Stats(baseStats);
        foreach (StatusEffect statusEffect in statusEffects)
        {
            currentStats = statusEffect.ApplyEffect(currentStats);
        }
    }
    public void AddElementEffect(ElementEffect elementEffect, Stats userStats) {
        elementEffects.Add(elementEffect);

        //Activating element effect after 2 elements
        if(elementEffects.Count >= 2 && elementSystem != null)
        {
            elementSystem.ActivateElement(this, userStats, elementEffects[0], elementEffects[1]);
            elementEffects.Clear();
        }
    }

    //TESTING FUNCTIONS
    public void PrintStats(Stats stats)
    {
        string output = $@"maxHP: {stats.maxHP} \n
                HP: {stats.HP} \n
                maxMP: {stats.maxMP} \n
                MP: {stats.MP} \n
                mpGain: {stats.mpGain} \n
                attack: {stats.attack} \n
            ";
        Debug.Log(output);
    }
}
