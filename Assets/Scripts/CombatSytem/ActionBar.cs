using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionBar : MonoBehaviour
{
    CombatController combatController;
    // Start is called before the first frame update
    void Start()
    {
        combatController = FindObjectOfType<CombatController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
