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
    GameObject[] overworldObjects;

    //Default values for testing
    public List<GameObject> testPlayers;
    public List<GameObject> testEnemies;
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            KillEnemies();
        }
    }
    public void InitalizeCombat(List<GameObject> _players, List<GameObject> _enemies)
    {
        InitalizeSide(_players, playerPositions, playersUI, players);
        InitalizeSide(_enemies, enemyPositions, enemiesUI, enemies);
    }
    private void InitalizeSide(List<GameObject> units, List<GameObject> positions, List<AssignStatBars> UI, List<GameObject> side)
    {
        int indexUI = 0;
        GameObject holder;
        //instantiate unit + setting position + adding to list 
        foreach (GameObject position in positions)
        {
            if (indexUI < units.Count)
            {
                holder = Instantiate(units[indexUI]);
                holder.transform.SetParent(position.transform);
                side.Add(holder);
            }
            else
            {
                position.SetActive(false);
            }
            indexUI++;
        }
        indexUI = 0;
        foreach (AssignStatBars _UI in UI)
        {

            if (indexUI < side.Count)
            {
                _UI.AssignCombatUnit(side[indexUI].GetComponent<CombatUnit>());
            }
            else
            {
                _UI.gameObject.SetActive(false);
            }
            indexUI++;
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

        if(!enemyAlive || !playerAlive)
        {
            EndCombat(true);
        }
    }
    public void SaveOverWorld(GameObject[] _overworldObects)
    {
        overworldObjects = _overworldObects;
    }
}
