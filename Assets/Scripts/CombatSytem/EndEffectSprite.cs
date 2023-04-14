using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndEffectSprite : MonoBehaviour
{
    public Animator animator;
    public AnimatorOverrideController animatorOverrideController;
    public string baseCase = "BaseCase";
    private void Awake()
    {
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180, 0);
    }

    public void EndAnimation()
    {
        Destroy(gameObject);
    }
}
