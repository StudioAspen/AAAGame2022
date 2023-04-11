using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RegularStrike : AlonzoSkill
{
    public RegularStrike(AlonzoCombatUnit _owner = null)
    {
        name = "Regular Strike";
        owner = _owner;
        mpCost = 20f;
        targetAmount = 1;
        animation = Resources.Load<AnimationClip>("Animations/CombatSystem/Alonzo/AlonzoRegularStrike");
    }

    public override void UseMove(List<CombatUnit> _targets, CombatUnit _user)
    {
        targets = new List<CombatUnit>(_targets);
        user = _user;

        skillAnimation = user.GetComponent<SkillAnimationComponent>();
        skillAnimation.skillActivation.AddListener(ActivateSkill);

        //Setting up target movement
        Vector3 holder = user.transform.position;
        skillAnimation.originalPos = new Vector3(holder.x, holder.y, holder.z);
        skillAnimation.startMove.AddListener(SetMoveTarget);

        //Setting Animation
        Animator animator = user.GetComponent<Animator>();
        AnimationOverride.SetAnimationClip(animator, overrideController, "BaseCase", animation);
    }
    public void ActivateSkill()
    {
        targets[0].TakeDamage(user.currentStats.attack);
        targets[0].AddElementStatus(new ElementStatus(owner.charge, owner));

        owner.SetCharge(Element.NONE);
        user.ChangeMP(-mpCost);

        skillAnimation.skillActivation.RemoveListener(ActivateSkill);
    }
    public void SetMoveTarget()
    {
        float timingEndMarker = animation.events[2].time;
        curve = AnimationCurve.Linear(0, 0, timingEndMarker, 1);
        skillAnimation.startMove.AddListener(SetMoveTargetOrigin);
        skillAnimation.startMove.RemoveListener(SetMoveTarget);

        skillAnimation.SetMoveToTarget(targets[0].transform.position + Vector3.left, curve);
    }
    public void SetMoveTargetOrigin()
    {
        float timingStartMarker = animation.events[5].time;
        curve = AnimationCurve.EaseInOut(0, 0, animation.length - timingStartMarker, 1);

        skillAnimation.SetMoveToOrigin(curve);
        skillAnimation.startMove.RemoveListener(SetMoveTargetOrigin);
    }
}
