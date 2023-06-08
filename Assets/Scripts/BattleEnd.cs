using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class BattleEnd : MonoBehaviour
{
    public Button button;
    public bool battleEnd;
    public GameObject character;

    public bool battleScene = true;

    [SerializeField]
    private CharacterStats characterStats;

    public void OnButtonPress()   
    {
        Debug.Log("pressed");
        battleEnd = true;

    }
    void Update()
    {
        if (battleEnd == true)
        {
            characterStats.battleScene = false;
            SceneManager.LoadScene("Overworld");
            character.transform.position= characterStats.overworldPos;
            battleEnd = false;

        }

    }
    
}
