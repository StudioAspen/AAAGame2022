using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CombatController : MonoBehaviour
{
    public List<GameObject> players;
    public List<GameObject> playerPositions;
    public List<AssignStatBars> playersUI;
    public List<GameObject> enemies;
    public List<GameObject> enemyPositions;
    public List<AssignStatBars> enemiesUI;
    public ActionBar actionBar;
    GameObject[] overworldObjects;

    //Default values for testing
    public List<GameObject> testPlayers;
    public List<GameObject> testEnemies;

    private void Awake()
    {
        //InitalizeCombat(testPlayers, testEnemies); 
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            KillEnemies();
        }
    }
    public void InitalizeCombat(List<CombatData> _players, List<CombatData> _enemies)
    {
        InitalizeSide(_players, playerPositions, playersUI, ref players);
        InitalizeSide(_enemies, enemyPositions, enemiesUI, ref enemies);
        actionBar.InitalizeBars(this);
    }
    private void InitalizeSide(List<CombatData> data, List<GameObject> positions, List<AssignStatBars> UI, ref List<GameObject> side)
    {
        List<GameObject> units = new List<GameObject>();

        foreach(CombatData _data in data)
        {
            units.Add(_data.combatPrefab);
        }
        int index = 0;
        GameObject holder;
        //instantiate unit + setting position + adding to list 
        foreach (GameObject position in positions)
        {
            if (index < units.Count)
            {
                holder = Instantiate(units[index], position.transform);
                side.Add(holder);
            }
            else
            {
                //Disabling Unused Positions
                position.SetActive(false);
            }
            index++;
        }


        //Initalizing combat units
        index = 0;
        foreach (GameObject combatPrefab in side)
        {
            combatPrefab.GetComponent<CombatUnit>().InitalizeBaseCombatUnit(data[index]);
            index++;
        }

        //Assigning UI + activating vaid UI
        index = 0;
        foreach (AssignStatBars _UI in UI)
        {
            
            if (index < side.Count)
            {
                _UI.AssignCombatUnit(side[index].GetComponent<CombatUnit>());
            }
            else
            {
                //Disabliing Unused UI
                _UI.gameObject.SetActive(false);
            }
            index++;
        }


    }
    public void EndCombat(bool playerWon)
    {
        SceneManager.UnloadSceneAsync("CombatScene");
        foreach(GameObject a in overworldObjects)
        {
            a.SetActive(true);
        }
    }
    public void KillEnemies()
    {
        //Killing enemies
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

        if(!enemyAlive)
        {
            EndCombat(true);
        }
        if (!playerAlive)
        {
            EndCombat(false);
        }
    }
    public void SaveOverWorld(GameObject[] _overworldObects)
    {
        overworldObjects = _overworldObects;
    }
}
