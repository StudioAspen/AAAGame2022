using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatData : MonoBehaviour
{
    public List<string> skillKeys = new List<string>();
    public float maxHP;
    public float maxMP;
    public float moveCD;
    public float attack;


    public Stats baseStats = new Stats();
    public List<Skill> skills = new List<Skill>();

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void ApplyManualStats()
    {
        //Setting Hidden stats
        baseStats = new Stats(maxHP, maxMP, moveCD, attack);

        //Initalizing all skills from key list
        skills.Clear();
        foreach (string skillKey in skillKeys)
        {
            AddSkill(allAlonzoSkills[skillKey]);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
