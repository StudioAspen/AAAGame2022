using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CombatController : MonoBehaviour
{
    public GameObject skillButton;

    // Start is called before the first frame update
    void Start()
    {
                
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IntializeCombat(List<CombatUnit> playerUnits, List<CombatUnit> enemyUnits)
    {
        GameObject currentSkillButton = Instantiate(skillButton);
        currentSkillButton.GetComponentInChildren<TMP_Text>();
        currentSkillButton.GetComponent<Button>();

        playerUnits[0].basicAttack.UseMove();
        

        BasicAttack.();
    }
}
