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
            Skill selectedSkill = combatUnit.skills[Random.Range(0, combatUnit.skills.Count)];
            List<CombatUnit> targets = new List<CombatUnit>();

            if(selectedSkill.targetAmount == -1)
            {
                // adding all targets for special case
                foreach (GameObject player in combatController.players)
                {
                    targets.Add(player.GetComponent<CombatUnit>());
                }
            }
            else
            {
                //Adding random targets according to amount of targets
                int playerAliveCount = combatController.GetPlayerAliveCount();
                while (targets.Count < selectedSkill.targetAmount && selectedSkill.targetAmount <= playerAliveCount)
                {
                    int randomTargetIndex = Random.Range(0, combatController.players.Count);
                    CombatUnit selectedCombatUnit = combatController.players[randomTargetIndex].GetComponent<CombatUnit>();

                    if(!targets.Contains(selectedCombatUnit))
                    {
                        targets.Add(selectedCombatUnit);
                    }
                }
            }

            selectedSkill.UseMove(targets, combatUnit);
            combatUnit.ResetTimer();
        }
    }
}
