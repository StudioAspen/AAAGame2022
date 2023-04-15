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
    public Image alonzoChargeIcon;
    public Image profileImage;

    //Skill List
    public GameObject skillList;
    public VerticalLayoutGroup verticalLayoutGroup;
    public GameObject skillButton; //Prefab to instantiate
    public List<GameObject> skillButtons;


    public GameObject debuffList;
    public GridLayoutGroup gridLayout;
    public GameObject debuffIcon; //Prefab to instantiate
    public List<GameObject> debuffs;

    private bool previousSelected;

    private void Update()
    {
        if (combatUnit != null)
        {
            //Updating Stat Bars
            UpdateStatBars();
            UpdateElementIcon();
            UpdateChargeIcon();
            UpdateStatusEffects();

            //player controller selecting the combat unit
            if (previousSelected != combatUnit.selected)
            {
                if (combatUnit.selected)
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
    }

    public void AssignCombatUnit(CombatUnit _combatUnit)
    {
        combatUnit = _combatUnit;
        UpdateMoveList();
        UpdateElementIcon();
        previousSelected = combatUnit.selected;
        profileImage.sprite = combatUnit.profile;
        HideSkillList();
    }
    public void UpdateStatBars()
    {
        HPSlider.value = combatUnit.currentHP / combatUnit.currentStats.maxHP;
        MPSlider.value = combatUnit.currentMP / combatUnit.currentStats.maxMP;
    }
    public void UpdateElementIcon()
    {
        //Swapping Icon
        elementIcon.sprite = ElementEffect.GetElementIcon(combatUnit.element);
    }
    public void UpdateChargeIcon()
    {
        //Swapping Icon
        AlonzoCombatUnit holder;
        if (combatUnit.TryGetComponent<AlonzoCombatUnit>(out holder))
        {
            alonzoChargeIcon.sprite = ElementEffect.GetElementIcon(holder.charge);
        }
        else
        {
            alonzoChargeIcon.sprite = ElementEffect.GetElementIcon(Element.NONE);
        }
    }
    public void UpdateStatusEffects()
    {
        //Destorying old icons
        for (int i = gridLayout.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(gridLayout.transform.GetChild(i).gameObject);
        }
        debuffs.Clear();


        GameObject holder;
        //Adding Element Status
        if (combatUnit.currentElementSatus != null)
        {
            holder = Instantiate(debuffIcon, gridLayout.transform);
            holder.GetComponentInChildren<Image>().sprite = ElementEffect.GetElementIcon(combatUnit.currentElementSatus.element);
            debuffs.Add(holder);
        }

        foreach (StatusEffect status in combatUnit.statusEffects)
        {
            //Adding Debuff
            holder = Instantiate(debuffIcon, gridLayout.transform);
            holder.GetComponentInChildren<Image>().sprite = status.icon;
            holder.GetComponentInChildren<Slider>().value = 1 - (status.duration/status.durationBase);
            debuffs.Add(holder);
        }
    }
    public void UpdateMoveList()
    {
        //Clearing old objects
        for(int i = verticalLayoutGroup.transform.childCount-1; i >= 0; i-- )
        {
            Destroy(verticalLayoutGroup.transform.GetChild(i).gameObject);
        }
        skillButtons.Clear();

        GameObject holder;
        //Adding Basic Attack
        if (combatUnit.basicAttack != null)
        {
            holder = Instantiate(skillButton, verticalLayoutGroup.transform);
            holder.GetComponentInChildren<TMP_Text>().text = combatUnit.basicAttack.name;
            holder.GetComponent<Button>().onClick.AddListener(() => SetCombatMove(combatUnit.basicAttack));
        }
        //Adding Skills
        foreach (Skill skill in combatUnit.skills)
        {
            holder = Instantiate(skillButton, verticalLayoutGroup.transform);
            holder.GetComponentInChildren<TMP_Text>().text = skill.name;
            holder.GetComponent<Button>().onClick.AddListener(() => SetCombatMove(skill));
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
            if (combatUnit.skills[i].EnoughMana(combatUnit))
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
