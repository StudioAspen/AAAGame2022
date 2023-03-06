using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AssignStatBars : MonoBehaviour
{
    public CombatUnit combatUnit;

    //UI
    public Slider HPSlider;
    public Slider MPSlider;
    public Image elementIcon;
    public Sprite fireIcon;

    //Skill List
    public GameObject skillList;
    public VerticalLayoutGroup verticalLayoutGroup;
    public GameObject skillButton; //Prefab to instantiate
    public List<GameObject> skillButtons;


    public GameObject debuffList;
    public GridLayout gridLayout;
    public GameObject debuffIcon; //Prefab to instantiate
    public List<GameObject> debuffs;



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
        UpdateElementIcon(combatUnit);
        previousSelected = combatUnit.selected;
    }
    public void UpdateStatBars(CombatUnit combatUnit)
    {
        HPSlider.value = combatUnit.currentHP / combatUnit.currentStats.maxHP;
        MPSlider.value = combatUnit.currentMP / combatUnit.currentStats.maxMP;
    }
    public void UpdateElementIcon(CombatUnit combatUnit)
    {
        //Swapping Icon
        elementIcon.sprite = ElementEffect.GetElementIcon(combatUnit.element);
    }
    /*
    public void UpdateStatusEffects(CombatUnit combatUnit)
    {
        //Adding Element Status
        GameObject holder = Instantiate(debuffIcon);
        holder.GetComponentInChildren<Image>().sprite = ElementEffect.GetElementIcon(combatUnit.element);
        holder.transform.SetParent(gridLayout.transform);
        debuffs.Add(holder);

        foreach (StatusEffect status in combatUnit.statusEffects)
        {
            //Adding Debuff
            holder = Instantiate(debuffIcon);
            holder.GetComponentInChildren<Image>().sprite = status.icon;
            holder.transform.SetParent(gridLayout.transform);
            debuffs.Add(holder);
        }
    }*/
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
    public void SetCombatMove(CombatMove combatMove)
    {
        FindObjectOfType<PlayerController>().SetCombatMove(combatMove);
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
    public void ShowSkillList()
    {
        skillList.SetActive(true);
    }
    public void HideSkillList()
    {
        skillList.SetActive(false);
    }
}
