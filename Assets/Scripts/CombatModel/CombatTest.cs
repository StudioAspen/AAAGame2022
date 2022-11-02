using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CombatTest : MonoBehaviour
{
    CombatUnit unit;
    TMP_Text statsDisplay;

    public CombatUnit unitForBasicAttack;
    public CombatUnit targetForBasicAttack;


    private void Start()
    {
        if (TryGetComponent<TMP_Text>(out statsDisplay))
        {
            if (!TryGetComponent<CombatUnit>(out unit))
            {
                statsDisplay.text = "Unit Not Found";
            }
        }
    }

    private void Update()
    {
        //Updating Stats
        if (unit != null)
        {
            Stats stats = unit.currentStats;
            string output = $@"
                maxHP: {stats.maxHP} \n
                HP: {stats.HP} \n
                maxMP: {stats.maxMP} \n
                MP: {stats.MP} \n
                mpGain: {stats.mpGain} \n
                attack: {stats.attack} \n
            ";

            statsDisplay.text = output;
        }
    }

    public void UseBasicAttack()
    {
        unitForBasicAttack.BasicAttack(targetForBasicAttack);
    }
}
