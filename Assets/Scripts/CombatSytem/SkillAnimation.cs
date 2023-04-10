using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SkillAnimation : MonoBehaviour
{
    public UnityEvent skillActivation;
    public void TriggerSkill()
    {
        skillActivation.Invoke();
    }
}
