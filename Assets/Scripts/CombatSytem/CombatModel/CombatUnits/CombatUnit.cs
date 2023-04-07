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
    public bool isPlayer;

    //Data (TEMPERARY)
    [SerializeField]
    public Sprite profile;

    //Animation


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
        currentStats = new Stats(baseStats);
        currentHP = baseStats.maxHP;
        currentMP = 0f;
        currentMoveCD = currentStats.SpeedToSec();
    }
    
    public void ResetTimer()
    {
        currentMoveCD = currentStats.SpeedToSec();
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
        if (elementStatus.element != Element.NONE)
        {
            if (currentElementSatus == null)
            {
                currentElementSatus = elementStatus;
            }
            else
            {
                elementStatus.ElementActivation(currentElementSatus.element, this);
                RemoveElementStatus();
            }
        }
    }
    public void RemoveElementStatus()
    {
        currentElementSatus = null;
    }
    public void ChangeMP(float amount)
    {
        if (amount < 0)
        {
            amount = amount * (amount + 100f) * 0.08f / (currentStats.defence + 8f); //Damage Calc
            if (isPlayer)
            {
                amount = amount * 0.25f;
            }
        }
        currentMP = Mathf.Clamp(currentMP + amount, 0, baseStats.maxMP);
    }
    public void TakeDamage(float amount)
    {
        amount = amount * (amount + 100f) * 0.08f / (currentStats.defence + 8f); //Damage Calc
        if(isPlayer)
        {
            amount = amount * 0.25f;
        }
        currentHP = Mathf.Clamp(currentHP - amount, 0, baseStats.maxHP);

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
