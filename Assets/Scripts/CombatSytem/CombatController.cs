using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class CombatController : MonoBehaviour
{
    //Combat Variables
    public List<GameObject> players;
    public List<GameObject> playerPositions;
    public List<AssignStatBars> playersUI;
    public List<GameObject> enemies;
    public List<GameObject> enemyPositions;
    public List<AssignStatBars> enemiesUI;
    public ActionBar actionBar;

    //Overworld Setup
    public GameObject root;
    public Transform combatCamera;
    private Vector3 overworldCameraOldPos;
    private Quaternion overworldCameraOldRot;
    private GameObject overworldCamera;
    private List<GameObject> overworldObjects = new List<GameObject>();
    private UnityEvent afterTransition = new UnityEvent();

    public BoxCollider clearAreaBox;
    public LayerMask cameraObstacle;
    public UnityEvent battleEndEvent = new UnityEvent();


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
        foreach(GameObject player in players)
        {
            player.GetComponent<CombatUnit>().isPlayer = true;
        }
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
        foreach(AssignStatBars statBars in playersUI)
        {
            statBars.gameObject.SetActive(false);
        }
        foreach (AssignStatBars statBars in enemiesUI)
        {
            statBars.gameObject.SetActive(false);
        }
        actionBar.gameObject.SetActive(false);
        root.SetActive(false);

        afterTransition.AddListener(ResetOverworld);
        StartCoroutine(SmoothCameraPos(overworldCamera.transform, overworldCameraOldPos, overworldCameraOldRot, 0.1f));
    }
    private void ResetOverworld()
    {
        SceneManager.UnloadSceneAsync("CombatScene");
        foreach (GameObject a in overworldObjects)
        {
            a.SetActive(true);
        }
        overworldObjects.Clear();
        battleEndEvent.Invoke();
    }
    public int GetPlayerAliveCount()
    {
        int count = 0;
        foreach (GameObject player in players)
        {
            if(!player.GetComponent<CombatUnit>().dead)
            {
                count++;
            }
        }
        return count;
    }
    public int GetEnemyAliveCount()
    {
        int count = 0;
        foreach (GameObject enemy in enemies)
        {
            if (!enemy.GetComponent<CombatUnit>().dead)
            {
                count++;
            }
        }
        return count;
    }
    public void KillEnemies()
    {
        //Killing enemies
        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].GetComponent<CombatUnit>().TakeDamage(10000);
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
    public void ClearArea()
    {
        Collider[] obstacles = Physics.OverlapBox(clearAreaBox.center, clearAreaBox.size / 2, 
            clearAreaBox.transform.rotation, cameraObstacle);

        foreach(Collider collider in obstacles)
        {
            overworldObjects.Add(collider.gameObject);
        }
    }
    public void SaveOverWorld(List<GameObject> _overworldObects)
    {
        foreach (GameObject a in _overworldObects)
        {
            overworldObjects.Add(a);
        }
    }
    public void SetRootPos(Vector3 _rootPos)
    {
        root.transform.position = _rootPos;
    }
    public void SetBattleEndEvent(UnityEvent _battleEndEvent)
    {
        battleEndEvent = _battleEndEvent;
    }
    public void SetCameraPos(GameObject _overworldCamera)
    {
        overworldCamera = _overworldCamera;
        Vector3 holderPos = overworldCamera.transform.position;
        overworldCameraOldPos = new Vector3(holderPos.x, holderPos.y, holderPos.z);
        Quaternion holderRot = overworldCamera.transform.rotation;
        overworldCameraOldRot = new Quaternion(holderRot.x, holderRot.y, holderRot.z, holderRot.w);

        StartCoroutine(SmoothCameraPos(overworldCamera.transform, combatCamera.position + root.transform.position, combatCamera.rotation, 0.1f));
    }
    IEnumerator SmoothCameraPos(Transform fromTransform, Vector3 toPos, Quaternion toRot, float speed)
    {
        while ((fromTransform.position - toPos).magnitude > 0.05f) {
            fromTransform.position = Vector3.Lerp(fromTransform.position, toPos, speed);
            fromTransform.rotation = Quaternion.Lerp(fromTransform.rotation, toRot, speed);

            yield return new WaitForSeconds(0.01f);
        }
        afterTransition.Invoke();
    }
}
