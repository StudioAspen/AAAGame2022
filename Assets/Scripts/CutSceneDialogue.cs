using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class CutSceneDialogue : MonoBehaviour
{
    public DialogueInteraction script;

    void Start()
    {
        UnityEvent afterDialogue = new UnityEvent();
        afterDialogue.AddListener(GoToOverworld);
        DialogueManager.Instance.StartDialogue(script, afterDialogue);
    }

    void GoToOverworld() {
        SceneManager.LoadScene("Overworld");
    }
}
