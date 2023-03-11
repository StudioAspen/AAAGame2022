using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Camera _mainCamera;
    CombatUnit selectedUser = null;
    CombatMove selectedMove = null;
    List<GameObject> players;

    private void Start()
    {
        players = FindAnyObjectByType<CombatController>().players;
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
                Debug.Log(foundObject.name);

                //If clicked player unit
                CombatUnit combatUnit;
                if(foundObject.TryGetComponent<CombatUnit>(out combatUnit))
                {
                    bool foundPlayer = false;
                    //Selected Player
                    foreach(GameObject player in players)
                    {
                        //player.GetComponent<AssignStatBars>().HideSkillList();
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
                    //Selected Enemy
                    if(selectedMove != null && !foundPlayer && !combatUnit.dead)
                    {
                        selectedMove.UseMove(combatUnit, selectedUser);
                        selectedUser.ResetTimer();
                        ResetTargeting();
                    }
                }
            }
        }
    }
    public void ResetTargeting()
    {
        selectedUser = null;
        selectedMove = null;
    }
    public void SetCombatMove(CombatMove combatMove)
    {
        selectedMove = combatMove;
    }
}
