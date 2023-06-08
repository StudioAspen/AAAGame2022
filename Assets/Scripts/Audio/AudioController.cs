using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class AudioController : MonoBehaviour
{
    public AudioSource firstSource;
    public AudioSource secondSource;
    bool isFirstSource = true;
    public void FadeIn(AudioClip audioClip)
    {
        if(isFirstSource)
        {
            if (firstSource.clip != audioClip)
            {
                isFirstSource = !isFirstSource;
                secondSource.clip = audioClip;
                secondSource.Play();
                StartCoroutine(FadeAudioSource.StartFade(secondSource, 2, 1));
                StartCoroutine(FadeAudioSource.StartFade(firstSource, 2, 0));
            }
        }
        else
        {
            if (secondSource.clip != audioClip)
            {
                isFirstSource = !isFirstSource;
                firstSource.clip = audioClip;
                firstSource.Play();
                StartCoroutine(FadeAudioSource.StartFade(firstSource, 2, 1));
                StartCoroutine(FadeAudioSource.StartFade(secondSource, 2, 0));
            }
        }
    }
}
