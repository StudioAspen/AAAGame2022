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

    public VerticalLayoutGroup verticalLayoutGroup;
    public GameObject skillButton;
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
        CDSlider.value = combatUnit.currentMoveCD / combatUnit.currentStats.moveCD;
    }
    public void UpdateMoveList(CombatUnit combatUnit)
    {
        GameObject holder = Instantiate(skillButton);
        holder.GetComponentInChildren<TMP_Text>().text = combatUnit.basicAttack.name;
        holder.transform.SetParent(verticalLayoutGroup.transform);

        foreach (Skill skill in combatUnit.skills)
        {
            holder = Instantiate(skillButton);
            holder.GetComponentInChildren<TMP_Text>().text = skill.name;
            holder.GetComponent<Button>().onClick.AddListener(() => SetCombatMove(skill));
            holder.transform.SetParent(verticalLayoutGroup.transform); 
        }
    }
    public void SetCombatMove(CombatMove combatMove)
    {

    }
}
