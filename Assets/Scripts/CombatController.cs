using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CombatController : MonoBehaviour
{
    public GameObject skillButton;
    public GameObject scrollViewContent;
    public List<GameObject> players;
    public List<GameObject> enemies;

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
        CombatUnit playerTest = playerUnits[0];
        CombatUnit enemyTest = enemyUnits[0];





        foreach(Skill skill in playerTest.skills)
        {
            //creating a buttons and setting parameters
            GameObject currentSkillButton = Instantiate(skillButton);
            TMP_Text text = currentSkillButton.GetComponentInChildren<TMP_Text>();
            Button button = currentSkillButton.GetComponent<Button>();
            text.text = skill.name;


            //setting button to parent
            currentSkillButton.transform.SetParent(scrollViewContent.transform);
        }


    }
}
