using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NPCQuestDisplay : MonoBehaviour
{
    public TextMeshProUGUI title;
    public TextMeshProUGUI description;
    public Button accept;
    public Button handIn;

    
    public void CloseMenu()
    {
        gameObject.SetActive(false);
    }
}
