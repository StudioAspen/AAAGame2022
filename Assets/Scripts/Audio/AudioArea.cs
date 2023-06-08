using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioArea : MonoBehaviour
{
    public AudioClip fadeInClip;
    private AudioController audioController;
    private void Start()
    {
        audioController = FindObjectOfType<AudioController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioController.FadeIn(fadeInClip);
        }
    }
}
