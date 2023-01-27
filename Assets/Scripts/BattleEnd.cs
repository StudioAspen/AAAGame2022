using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleEnd : MonoBehaviour
{
    public Button button;
    public bool battleEnd;
    public void OnButtonPress()   
    {
        Debug.Log("pressed");
        battleEnd = true;

    }
    void Update()
    {
        if (battleEnd == true)
        {
           
            SceneManager.LoadScene("Overworld");
            battleEnd = false;

        }

    }
    
        }
