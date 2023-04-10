using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Camera _mainCamera;
    CombatUnit selectedUser = null;
    CombatMove selectedMove = null;
    CombatController combatController;
    List<GameObject> players;
    List<CombatUnit> targets = new List<CombatUnit>();
    private void Start()
    {
        combatController = FindAnyObjectByType<CombatController>();
        players = combatController.players;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Checking click on an object
            Ray _ray;
            _ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

            Debug.DrawLine(_ray.GetPoint(0f), _ray.direction *100, Color.blue, 10f);

            RaycastHit _hit;
            if (Physics.Raycast(_ray, out _hit, 1000f))
            {
                GameObject foundObject = _hit.transform.gameObject;

                //If clicked player unit
                CombatUnit combatUnit;
                if(foundObject.TryGetComponent<CombatUnit>(out combatUnit))
                {
                    bool foundPlayer = false;
                    //Checking if Selected Player
                    foreach(GameObject player in players)
                    {
                        player.GetComponent<CombatUnit>().selected = false;
                        if (foundObject == player)
                        {
                            foundPlayer = true;
                            if (combatUnit.canMakeMove)
                            {
                                ResetTargeting();
                                selectedUser = combatUnit;
                                combatUnit.selected = true;
                            }
                        }
                    }
                    //Checking if Selected Enemy
                    if (selectedMove != null && !foundPlayer && !combatUnit.dead)
                    {
                        //Adding all enemies
                        if (selectedMove.targetAmount == -1)
                        {
                            foreach (GameObject enemy in combatController.enemies)
                            {
                                CombatUnit enemyUnit = enemy.GetComponent<CombatUnit>();
                                if (!enemyUnit.dead)
                                {
                                    targets.Add(enemyUnit);
                                }
                            }
                            StartUseMove();
                        }
                        else
                        {
                            //Adding enemy targets
                            int enemyAliveCount = combatController.GetEnemyAliveCount();
                            if (targets.Count < selectedMove.targetAmount && selectedMove.targetAmount <= enemyAliveCount)
                            {
                                targets.Add(combatUnit);
                            }
                            if (targets.Count == selectedMove.targetAmount)
                            {
                                StartUseMove();
                            }
                        }
                    }
                }
            }
        }
    }
    private void StartUseMove()
    {
        selectedMove.UseMove(targets, selectedUser);
        selectedUser.StartAttack();
        selectedUser.ResetTimer();
        ResetTargeting();
    }
    public void ResetTargeting()
    {
        selectedUser = null;
        selectedMove = null;
        targets.Clear();
    }
    public void SetCombatMove(CombatMove combatMove)
    {
        selectedMove = combatMove;
    }
}
