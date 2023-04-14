using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Events;

public class StartDialogue : MonoBehaviour
{
    public DialogueInteraction script;
    public Battle battle;
    public DialogueInteraction script2;

    bool canEnter = false;

    private void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player") == true && canEnter)
        {
            canEnter = false;

            // UnityEvent afterBattle = new UnityEvent();
            // afterBattle.AddListener(DialogueManager.Instance.StartDialogue(script));
            // battle.SetEndEvent(afterBattle);

            // UnityEvent afterDialogue = new UnityEvent();
            // afterDialogue.AddListener(StartCoroutine(battle.TriggerCombat()));
            // DialogueManager.Instance.StartDialogue(script, afterDialogue);

            DialogueManager.Instance.StartDialogue(script);
        }
    }

    public void ActivateTrigger() {
        canEnter = true;
    }
}
