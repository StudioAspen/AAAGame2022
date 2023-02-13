using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
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
    public bool selected = false;
    
    //For element activation
    private ElementSystem elementSystem;

    
    void Start()
    {
        //testing
        if(baseStats == null)
        {
            InitalizeCombatUnit(new CombatData(true));
        }


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

    //initalize combat unit with data
    public void InitalizeCombatUnit(CombatData combatData)
    {
        //Setting stats and moves from overworld
        baseStats = combatData.baseStats;
        basicAttack = combatData.basicAttack;
        skills = combatData.skills;

        //Initalized Values for current combat stats
        currentHP = baseStats.maxHP;
        currentMP = 0f;
        currentMoveCD = baseStats.moveCD;
        currentStats = new Stats(baseStats);
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
    private void ApplyAllStatusEffects()
    {
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
    public void RemoveElementEffect(ElementEffect elementEffect, Stats userStats)
    {
        if(elementEffects.Contains(elementEffect))
        {
            elementEffects.Remove(elementEffect);
        }
    }
    public void ChangeMP(float amount)
    {
        currentMP = Mathf.Clamp(currentMP + amount, 0, baseStats.maxMP);
    }
    public void ChangeHP(float amount)
    {
        currentHP = Mathf.Clamp(currentHP + amount, 0, baseStats.maxHP);

        if (currentHP <= 0f)
        {
            Die();
        }
    }
    public void Die()
    {
        dead = true;
        canMakeMove = false;

        //                          TEMPERARY
        CombatController combatController = FindObjectOfType<CombatController>();
        if(combatController != null)
        {
            combatController.UpdateDead();
        }
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
