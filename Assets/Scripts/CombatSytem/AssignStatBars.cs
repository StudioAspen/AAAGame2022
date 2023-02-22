using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AssignStatBars : MonoBehaviour
{
    public CombatUnit combatUnit;

    public Slider HPSlider;
    public Slider MPSlider;
    public Slider CDSlider;

    public GameObject skillList;
    public VerticalLayoutGroup verticalLayoutGroup;
    public GameObject skillButton; //Prefab to instantiate
    public List<GameObject> skillButtons;

    private bool previousSelected;

    void Start()
    {
        if (combatUnit != null)
        {
            AssignCombatUnit(combatUnit);
        }
        else {
            Debug.Log("No Combat Unit Assigned to Stat Bar: " + gameObject.name);
            AssignCombatUnit(new CombatUnit());
        }
        HideSkillList();
    }

    private void Update()
    {
        //Updating Stat Bars
        HPSlider.value = combatUnit.currentHP / combatUnit.currentStats.maxHP;
        MPSlider.value = combatUnit.currentMP / combatUnit.currentStats.maxMP;
        CDSlider.value = 1 - (combatUnit.currentMoveCD / combatUnit.currentStats.moveCD);

        //player controller selecting the combat unit
        if(previousSelected != combatUnit.selected)
        {
            if(combatUnit.selected)
            {
                ShowSkillList();
                UpdateCanUseSkill();
            }
            else
            {
                HideSkillList();
            }

            previousSelected = combatUnit.selected;
        }
    }

    public void AssignCombatUnit(CombatUnit _combatUnit)
    {
        combatUnit = _combatUnit;
        UpdateMoveList(combatUnit);
        previousSelected = combatUnit.selected;
    }
    public void UpdateStatBars(CombatUnit combatUnit)
    {
        HPSlider.value = combatUnit.currentHP / combatUnit.currentStats.maxHP;
        MPSlider.value = combatUnit.currentMP / combatUnit.currentStats.maxMP;
        CDSlider.value = 1-(combatUnit.currentMoveCD / combatUnit.currentStats.moveCD);
    }
    public void UpdateMoveList(CombatUnit combatUnit)
    {
        //Adding Basic Attack
        GameObject holder = Instantiate(skillButton);
        holder.GetComponentInChildren<TMP_Text>().text = combatUnit.basicAttack.name;
        holder.GetComponent<Button>().onClick.AddListener(() => SetCombatMove(combatUnit.basicAttack));
        holder.transform.SetParent(verticalLayoutGroup.transform);

        foreach (Skill skill in combatUnit.skills)
        {
            //Adding Skills
            holder = Instantiate(skillButton);
            holder.GetComponentInChildren<TMP_Text>().text = skill.name;
            holder.GetComponent<Button>().onClick.AddListener(() => SetCombatMove(skill));
            holder.transform.SetParent(verticalLayoutGroup.transform);
            skillButtons.Add(holder);
        }
    }
    public void UpdateCanUseSkill()
    {
        for (int i = 0; i < skillButtons.Count; i++)
        {
            Button button = skillButtons[i].GetComponent<Button>();
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
    public void SetCombatMove(CombatMove combatMove)
    {
        FindObjectOfType<PlayerController>().SetCombatMove(combatMove);
    }
    public void ShowSkillList()
    {
        skillList.SetActive(true);
    }
    public void HideSkillList()
    {
        skillList.SetActive(false);
    }
}
