using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatUnit : MonoBehaviour
{
    //Stats of unit
    private Stats baseStats;
    public Stats currentStats;

    //Available Skills on unit
    Skill[] skillSet;

    //Effects on unit
    StatusEffect[] statusEffects;
    ElementEffect[] elementEffects;

    float moveCDBase;
    float moveCD;

    void Start()
    {
        //TESTING intialized values
        baseStats = new Stats(100, 100, 100, 0, 10, 10);

        //Initalized Values
        moveCD = moveCDBase;
        currentStats = baseStats;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            PrintStats(currentStats);
        }
    }

    public void BasicAttack(CombatUnit target) {
        currentStats.MP += currentStats.mpGain;
    }
    public void TakeDamage(float amount) {
        currentStats.HP -= amount;
    }
    public void AddStatEffect(StatusEffect statusEffect) { }
    public void ApplyAllStatusEffect() { }
    public void AddElementEffect(ElementEffect elementEffect) { }

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
