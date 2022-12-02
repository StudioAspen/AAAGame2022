using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Camera _mainCamera;
    CombatUnit selectedUser = null;
    CombatMove selectedMove = null;

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray _ray;
            _ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

            Debug.DrawLine(_ray.GetPoint(0f), _ray.direction *100, Color.blue, 10f);

            RaycastHit _hit;
            if (Physics.Raycast(_ray, out _hit, 1000f))
            {
                CombatUnitController combatUnitController;
                if(_hit.transform.gameObject.TryGetComponent<CombatUnitController>(out combatUnitController))
                {
                    ResetTargeting();
                    selectedUser = combatUnitController.combatUnit;
                    Debug.Log("Clicked on: " + selectedUser.name);
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
