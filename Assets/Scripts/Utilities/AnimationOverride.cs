using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationOverride : MonoBehaviour
{
    public static void SetAnimationClip(Animator animator, AnimatorOverrideController overrideController, string baseCase, AnimationClip animationClip)
    {
        List<KeyValuePair<AnimationClip, AnimationClip>> overrides = 
            new List<KeyValuePair<AnimationClip, AnimationClip>>(overrideController.overridesCount);

        overrideController.GetOverrides(overrides);
        for (int i = 0; i < overrides.Count; ++i)
        {
            if (overrides[i].Key.name == baseCase)
            {
                overrides[i] = new KeyValuePair<AnimationClip, AnimationClip>(overrides[i].Key, animationClip);
            }
            else
            {
                overrides[i] = new KeyValuePair<AnimationClip, AnimationClip>(overrides[i].Key, overrides[i].Value);
            }
        }
        overrideController.ApplyOverrides(overrides);
        animator.runtimeAnimatorController = overrideController;
    }
}
