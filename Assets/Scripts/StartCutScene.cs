using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class StartCutScene : MonoBehaviour
{
    public GameObject Timeline;
    PlayableDirector director;
    private void Start()
    {
        director = Timeline.GetComponent<PlayableDirector>();
    }

    private void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player") == true)
        {
            director.Play();

        }


    }

}
