using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AssignStatBars : MonoBehaviour
{
    public Slider HPSlider;
    public Slider MPSlider;
    public Slider CDSlider;

    public GameObject skillList;
    public VerticalLayoutGroup verticalLayoutGroup;
    public GameObject skillButton;
    public List<GameObject> skillButtons;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
