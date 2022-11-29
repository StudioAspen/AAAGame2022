using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatUnit : MonoBehaviour
{
    //Available moves and base stats on unit
    private Stats baseStats;
    public List<Skill> skills = new List<Skill>();
    public BasicAttack basicAttack;

    //Current Stats
    public Stats currentStats;
    public float currentHP;
    public float currentMP;
    public float currentMoveCD;

    //Current effects on unit
    public List<StatusEffect> statusEffects = new List<StatusEffect>();
    public List<ElementEffect> elementEffects = new List<ElementEffect>();

    //Other Stats
    public bool canMakeMove = false;
    public bool dead = false;
    
    //For element activation
    private ElementSystem elementSystem;

    void Start()
    {
        //TESTING intialized values
        baseStats = new Stats();
        basicAttack = new BasicAttack();
        skills.Add(new FireSkill());
        skills.Add(new WaterSkill());
        skills.Add(new RegularSkill());

        //Initalized Values
        currentHP = baseStats.maxHP;
        currentMP = 0f;
        currentMoveCD = baseStats.moveCD;
        currentStats = new Stats(baseStats);

        //Getting element system
        elementSystem = FindObjectOfType<ElementSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead)
        {
            //Updating CD Timer
            currentMoveCD = Mathf.Max(0f, currentMoveCD - Time.deltaTime);
            if (currentMoveCD <= 0f)
            {
                canMakeMove = true;
            }
        }

        //Time Limit on Status Effects
        for (int i = 0; i < statusEffects.Count; i++)
        {
            StatusEffect statusEffect = statusEffects[i];
            statusEffect.duration -= Time.deltaTime;
            if (statusEffect.duration <= 0f)
            {
                RemoveStatEffect(statusEffect);
            }
        }
    }
    public void ResetTimer()
    {
        currentMoveCD = baseStats.moveCD;
        canMakeMove = false;
    }
    public void AddStatEffect(StatusEffect statusEffect) {
        statusEffects.Add(statusEffect);
        ApplyAllStatusEffects();
    }
    public void RemoveStatEffect(StatusEffect statusEffect)
    {
        statusEffects.Remove(statusEffect);
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
    public void AddMP(float amount)
    {
        currentMP = Mathf.Min(baseStats.maxMP, currentMP + amount);
    }
    public void TakeDamage(float amount)
    {
        currentHP -= amount;

        if (currentHP <= 0f)
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
                HP: {currentHP} \n
                maxMP: {stats.maxMP} \n
                MP: {currentMP} \n
                attack: {stats.attack} \n
            ";
        Debug.Log(output);
    }
}
