using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class StartCutScene : MonoBehaviour
{
    public Collider player;
    public Collider ground;
    public Collider trigger;

    private PlayableDirector director;
    public GameObject controlPanel;



    private void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player") == true)
        {

        }


    }

}
