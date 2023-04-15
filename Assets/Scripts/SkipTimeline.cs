using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SkipTimeline : MonoBehaviour
{
    PlayableDirector playableDirector;
    private void Start()
    {
        playableDirector = GetComponent<PlayableDirector>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            while (playableDirector.time < playableDirector.duration)
            {
                playableDirector.time += 1f;
            }
        }
    }
}
