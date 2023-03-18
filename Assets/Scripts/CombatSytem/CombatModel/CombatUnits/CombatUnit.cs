using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using UnityEngine.UI;
abstract public class CombatUnit : MonoBehaviour
{
    //Available moves and base stats on unit
    protected Stats baseStats;
    public List<Skill> skills = new List<Skill>();
    public BasicAttack basicAttack;

    //Current Stats
    public Stats currentStats;
    public float currentHP;
    public float currentMP;
    public float currentMoveCD;
    public Element element;

    //Current effects on unit
    public List<StatusEffect> statusEffects = new List<StatusEffect>();
    public ElementStatus currentElementSatus;

    //Other Stats
    public bool canMakeMove = false;
    public bool dead = false;
    public bool selected = false;

    //Data (TEMPERARY)
    [SerializeField]
    public Sprite profile;

    private void Start()
    {
        InitalizeCombatUnit();
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
    abstract public void InitalizeBaseCombatUnit(CombatData combatData);
    
    public void InitalizeCombatUnit()
    {
        //Initalizing current Values
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
    public void AddElementStatus(ElementStatus elementStatus)
    {
        if(currentElementSatus == null)
        {
            currentElementSatus = elementStatus;
        }
        else
        {
            elementStatus.ElementActivation(currentElementSatus.element, this);
            RemoveElementStatus();
        }
    }
    public void RemoveElementStatus()
    {
        currentElementSatus = null;
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
