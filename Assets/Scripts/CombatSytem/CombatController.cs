using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CombatController : MonoBehaviour
{
    public List<GameObject> players;
    public List<GameObject> enemies;

    GameObject root; //to enable overworld
    Quest questObjective;

    // Start is called before the first frame update
    private void Awake()
    {
        //////////////TESTING INITALIZATION/////////////////////////
        List<CombatData> playerData = new List<CombatData>();
        playerData.Add(new CombatData(true));
        playerData.Add(new CombatData(true));
        playerData.Add(new CombatData(true));
        List<CombatData> enemyData = new List<CombatData>();
        enemyData.Add(new CombatData(false));
        enemyData.Add(new CombatData(false));
        enemyData.Add(new CombatData(false));

        InitalizeCombat(playerData, enemyData);
        ///////////////////////////////////////////////////////////////

    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            KillEnemies();
        }
    }

    public void InitalizeCombat(List<CombatData> playerUnits, List<CombatData> enemyUnits)
    {
        //Initalizing Players
        for (int i = 0; i < players.Count; i++)
        {
            players[i].GetComponent<CombatUnit>().InitalizeCombatUnit(playerUnits[i]);
        }

        //Initalizing enemies
        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].GetComponent<CombatUnit>().InitalizeCombatUnit(enemyUnits[i]);
        }
    }
    public void EndCombat(bool playerWon)
    {
        SceneManager.UnloadSceneAsync("CombatScene");
        FindObjectOfType<DisableRoot>(true).gameObject.SetActive(true);
        FindObjectOfType<QuestManager>(true).CompleteQuest(questObjective);
    }

    public void KillEnemies()
    {
        //Initalizing enemies
        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].GetComponent<CombatUnit>().ChangeHP(-10000);
        }
    }
    public void UpdateDead()
    {
        bool playerAlive = false;
        //Initalizing Players
        for (int i = 0; i < players.Count; i++)
        {
            if(!players[i].GetComponent<CombatUnit>().dead)
            {
                playerAlive = true;
            }
        }
        bool enemyAlive = false;
        //Initalizing enemies
        for (int i = 0; i < enemies.Count; i++)
        {
            if (!enemies[i].GetComponent<CombatUnit>().dead)
            {
                enemyAlive = true;
            }
        }

        if(!enemyAlive || !playerAlive)
        {
            EndCombat(true);
        }
    }

    public void SaveOverWorld(Quest quest)
    {
        Debug.Log(quest.title);
        questObjective = quest;
    }
}
