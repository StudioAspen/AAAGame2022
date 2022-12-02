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
    public void EndCombat()
    {
        SceneManager.UnloadSceneAsync("CombatSystem");
    }
    public void UpdateDead()
    {
        bool alive = false;
        //Initalizing Players
        for (int i = 0; i < players.Count; i++)
        {
            if(!players[i].GetComponent<CombatUnit>().dead)
            {
                alive = true;
            }
        }

        //Initalizing enemies
        for (int i = 0; i < enemies.Count; i++)
        {
            if (!enemies[i].GetComponent<CombatUnit>().dead)
            {
                alive = true;
            }
        }

        if(!alive)
        {
            EndCombat();
        }
    }
}
