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
    void Start()
    {
        //////////////TESTING INITALIZATION/////////////////////////
        List<CombatData> playerData = new List<CombatData>();
        playerData.Add(new CombatData());
        playerData.Add(new CombatData());
        playerData.Add(new CombatData());
        List<CombatData> enemyData = new List<CombatData>();
        enemyData.Add(new CombatData());
        enemyData.Add(new CombatData());
        enemyData.Add(new CombatData());

        InitalizeCombat(playerData, enemyData);
        ///////////////////////////////////////////////////////////////
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
        foreach (AssignStatBars statBars in FindObjectsOfType<AssignStatBars>())
        {
            statBars.UpdateMoveList();
        }
    }
    public void EndCombat()
    {
        SceneManager.UnloadSceneAsync("CombatSystem");
    }
    /// FOR TESTING /////////
    public void KillAllEnemies()
    {
        foreach(GameObject enemy in enemies)
        {
            enemy.GetComponent<CombatUnit>().ChangeHP(-10000);
        }
    }
}
