using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/SkillEffectData", order = 1)]
public class SkillEffectData : ScriptableObject
{
    public GameObject particle;
    public AnimationClip animation;
    public bool isChild = false;
    public bool xFlipped = false;
    public bool yFlipped = false;
    public float scale = 1f;
    public Vector3 offset = Vector3.zero;
}
