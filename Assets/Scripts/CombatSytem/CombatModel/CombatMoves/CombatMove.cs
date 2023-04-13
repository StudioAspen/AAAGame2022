using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CombatMove
{
    public string name;
    public int targetAmount; // -1 is all available targets
    public List<CombatUnit> targets;
    public CombatUnit user;
    protected AnimationClip animation;
    protected AnimationCurve curve;
    protected SkillAnimationComponent skillAnimation;
    protected const float strikeDistance = 5f;

    public abstract void UseMove(List<CombatUnit> target, CombatUnit user);

    public AnimationCurve CalculateDashCurve(AnimationClip animationClip, int dashIndex)
    {
        bool foundStart = false;
        int currentDashIndex = -1;
        float startTime = 0;
        float endtime = 0;
        foreach(AnimationEvent animationEvent in animationClip.events)
        {
            if(animationEvent.functionName == "StartMove")
            {
                foundStart = true;
                startTime = animationEvent.time;
            }
            if(animationEvent.functionName == "EndMove")
            {
                if(foundStart)
                {
                    endtime = animationEvent.time;
                    currentDashIndex++;
                    foundStart = false;
                }
                else
                {
                    Debug.LogWarning("Warning: Mismatch Number of StartMove and EndMove in animation");
                }
            }
            if(currentDashIndex == dashIndex)
            {
                break;
            }
        }

        return AnimationCurve.EaseInOut(0, 0, endtime - startTime, 1);
    }
}
