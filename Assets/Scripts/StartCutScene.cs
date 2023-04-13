using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Events;

public class StartCutScene : MonoBehaviour
{
    public DialogueInteraction script;

    // public GameObject preCutsceneTimeline;
    // public GameObject postCutsceneTimeline;
    // PlayableDirector preCutsceneDirector;
    // PlayableDirector postCutsceneDirector;

    bool canEnter = true;

    // private void Start()
    // {
    //     preCutsceneDirector = preCutsceneTimeline.GetComponent<PlayableDirector>();
    //     postCutsceneDirector = postCutsceneTimeline.GetComponent<PlayableDirector>();
    // }

    private void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player") == true && canEnter)
        {
            canEnter = false;
            // StartCoroutine(PlayCutscene());
            DialogueManager.Instance.StartDialogue(script);
        }
    }

    // private IEnumerator PlayCutscene() {
    //     preCutsceneDirector.Play();
    //     yield return new WaitForSeconds((float)preCutsceneDirector.duration);

    //     UnityEvent afterDialogue = new UnityEvent();
    //     afterDialogue.AddListener(PlayPostCutscene);
    //     DialogueManager.Instance.StartDialogue(script, afterDialogue);
    // }

    // private void PlayPostCutscene() {
    //     postCutsceneDirector.Play();
    // }
}
