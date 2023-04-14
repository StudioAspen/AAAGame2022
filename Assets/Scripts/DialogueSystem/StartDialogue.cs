using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Events;

public class StartDialogue : MonoBehaviour
{
    public DialogueInteraction script;
    public Battle battle1;
    public DialogueInteraction script2;
    public Battle battle2;
    public DialogueInteraction script3;

    public bool canEnter;
    public StartDialogue next;

    private void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player") == true && canEnter)
        {
            canEnter = false;
            if (next != null) next.canEnter = true;

            UnityEvent startDialogue3 = new UnityEvent();
            UnityEvent startBattle2 = new UnityEvent();
            UnityEvent startDialogue2 = new UnityEvent();
            UnityEvent startBattle1 = new UnityEvent();

            // dialogue 3
            if (script3 != null)
            {
                startDialogue3.AddListener
                (
                    delegate { DialogueManager.Instance.StartDialogue(script3); }
                );
                battle2.battleData.afterCombat = startDialogue3;
            }

            // battle 2
            if (battle2 != null)
            {
                startBattle2.AddListener
                (
                    delegate { battle2.StartCombat(battle2.battleData); }
                );
            }

            // dialogue 2
            if (script2 != null)
            {
                startDialogue2.AddListener
                (
                    delegate { DialogueManager.Instance.StartDialogue(script2, startBattle2); }
                );
                battle1.battleData.afterCombat = startDialogue2;
            }

            // battle 1
            if (battle1 != null)
            {
                startBattle1.AddListener
                (
                    delegate { battle1.StartCombat(battle1.battleData); }
                );
                DialogueManager.Instance.StartDialogue(script, startBattle1);
            }
            else 
            {
                DialogueManager.Instance.StartDialogue(script);
            }

        }
    }
}
