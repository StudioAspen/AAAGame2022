using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string sceneToLoad;
    public Vector3 playerPosition;
    public VectorValue startingPosition;

    public Animator animator;
    public Rigidbody rb;


    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            startingPosition.initialValue = playerPosition;
            animator.SetTrigger("FadeOut");
            
            
        }
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(sceneToLoad);
        rb.position = startingPosition.initialValue;
    }
}
