using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioArea : MonoBehaviour
{
    public AudioSource fadeIn;
    public AudioSource fadeOut;
    public float duration;
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(FadeAudioSource.StartFade(fadeIn, duration, 1));
        StartCoroutine(FadeAudioSource.StartFade(fadeOut, duration, 0));
    }
}
