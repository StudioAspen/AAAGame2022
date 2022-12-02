using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonVisable : MonoBehaviour
{
    public GameObject PlayerSelected;
    public GameObject AttackButton;
    public GameObject FireSkillButton;

    // Start is called before the first frame update
    void Start()
    {
        AttackButton.SetActive(false);
        FireSkillButton.SetActive(false);
    }

    // Update is called once per frame

    public void Update()
    {
        // Compare selected gameObject with referenced Button gameObject
        /*
        if (EventSystem.current.currentSelectedGameObject == PlayerSelected 
            || EventSystem.current.currentSelectedGameObject == AttackButton 
            || EventSystem.current.currentSelectedGameObject == FireSkillButton)
        {
            Debug.Log(this.PlayerSelected.name + " was selected");
            AttackButton.SetActive(true);
            FireSkillButton.SetActive(true);
        }
        else
        {
            AttackButton.SetActive(false);
            FireSkillButton.SetActive(false);
        }
        */
    }
}
                                            