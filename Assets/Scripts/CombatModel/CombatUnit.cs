using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatUnit : MonoBehaviour
{
    //Stats of unit
    private Stats baseStats;
    public Stats currentStats;

    //Available moves on unit
    public List<Skill> skills = new List<Skill>();
    public BasicAttack basicAttack;

    //Effects on unit
    public List<StatusEffect> statusEffects = new List<StatusEffect>();
    public List<ElementEffect> elementEffects;

    public float moveCDBase;
    private float moveCD;
    public bool canMakeMove = false;
    public bool dead = false;

    //For element activation
    private ElementSystem elementSystem;

    void Start()
    {
        //TESTING intialized values
        baseStats = new Stats(100, 100, 100, 0, 10, 10);
        basicAttack = new BasicAttack();
        skills.Add(new FireSkill());
        skills.Add(new WaterSkill());

        //Initalized Values
        moveCD = moveCDBase;
        currentStats = new Stats(baseStats);

        elementSystem = FindObjectOfType<ElementSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead)
        {
            moveCD = Mathf.Max(0f, moveCD - Time.deltaTime);
            if (moveCD <= 0f)
            {
                canMakeMove = true;
            }
        }
    }
    public void ResetTimer()
    {
        moveCD = moveCDBase;
        canMakeMove = false;
    }
    public void AddStatEffect(StatusEffect statusEffect) {
        statusEffects.Add(statusEffect);
        ApplyAllStatusEffects();
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
    public void ApplyAllStatusEffects()
    {
        //Recalculating stats
        currentStats = new Stats(baseStats);
        foreach (StatusEffect statusEffect in statusEffects)
        {
            currentStats = statusEffect.ApplyEffect(currentStats);
        }
    }
    public void TakeDamage(float amount)
    {
        currentStats.HP -= amount;

        if (currentStats.HP <= 0f)
        {
            Die();
        }
    }
    public void Die()
    {
        dead = true;
        canMakeMove = false;
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
