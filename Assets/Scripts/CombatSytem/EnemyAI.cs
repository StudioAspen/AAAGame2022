using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    CombatUnit combatUnit;
    CombatController combatController;
    // Start is called before the first frame update
    void Start()
    {
        combatUnit = GetComponent<CombatUnit>();
        combatController = FindObjectOfType<CombatController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Attacks a random target with a random move
        if(combatUnit.canMakeMove)
        {
            int randomTargetIndex = Random.Range(0, combatController.players.Count);
            CombatUnit selectedTarget = combatController.players[randomTargetIndex].GetComponent<CombatUnit>();
            Skill selectedSkill =  combatUnit.skills[Random.Range(0, combatUnit.skills.Count)];

            selectedSkill.UseMove(selectedTarget, combatUnit);
            combatUnit.ResetTimer();
        }
    }
}
