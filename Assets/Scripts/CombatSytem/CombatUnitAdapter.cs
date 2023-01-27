using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatUnitAdapter : MonoBehaviour
{
    public CombatUnit combatUnit;
    public AssignStatBars assignStatBars;
    // Start is called before the first frame update
    void Start()
    {
        combatUnit = GetComponent<CombatUnit>();
        assignStatBars.UpdateMoveList(combatUnit);
        assignStatBars.HideSkillList();
    }

    // Update is called once per frame
    void Update()
    {
        assignStatBars.UpdateStatBars(combatUnit);

    }

    public void UpdateCanUseSkill()
    {
        for (int i = 0; i < assignStatBars.skillButtons.Count; i++)
        {
            Button button = assignStatBars.skillButtons[i].GetComponent<Button>();
            if (combatUnit.skills[i].CanUse(combatUnit))
            {
                button.interactable = true;
            }
            else
            {
                button.interactable = false;
            }
        }
    }
}
