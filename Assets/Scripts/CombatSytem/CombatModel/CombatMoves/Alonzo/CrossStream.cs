using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossStream : AlonzoSkill
{
    public CrossStream(AlonzoCombatUnit _owner = null)
    {
        name = "Cross Stream";
        owner = _owner;
        mpCost = 25f;
        targetAmount = 2;
        animation = Resources.Load<AnimationClip>("Animations/CombatSystem/Alonzo/AlonzoCrosstream");
    }

    public override void UseMove(List<CombatUnit> _targets, CombatUnit _user)
    {
        targets = new List<CombatUnit>(_targets);
        user = _user;

        skillAnimation = user.GetComponent<SkillAnimationComponent>();
        skillAnimation.skillActivation.AddListener(StrikeFirstTarget);

        //Setting up target movement
        Vector3 holder = user.transform.position;
        skillAnimation.originalPos = new Vector3(holder.x, holder.y, holder.z);
        skillAnimation.startMove.AddListener(SetMoveTargetFirst);

        //Setting Animation
        Animator animator = user.GetComponent<Animator>();
        AnimationOverride.SetAnimationClip(animator, overrideController, "BaseCase", animation);

        //Double Strike
        owner.SetCharge(Element.NONE);
        user.ChangeMP(-mpCost);
    }
    public void StrikeFirstTarget()
    {
        owner.SetCharge(targets[0].element);
        targets[0].TakeDamage(user.currentStats.attack);

        skillAnimation.skillActivation.AddListener(StrikeSecondTarget);
        skillAnimation.skillActivation.RemoveListener(StrikeFirstTarget);
    }
    public void StrikeSecondTarget()
    {
        targets[1].TakeDamage(user.currentStats.attack);
        targets[1].AddElementStatus(new ElementStatus(owner.charge, targets[1]));

        skillAnimation.skillActivation.RemoveListener(StrikeSecondTarget);
    }

    public void SetMoveTargetFirst()
    {
        curve = CalculateDashCurve(animation, 0);
        skillAnimation.startMove.AddListener(SetMoveTargetSecond);
        skillAnimation.startMove.RemoveListener(SetMoveTargetFirst);

        skillAnimation.SetMoveToTarget(targets[0].transform.position + Vector3.left * strikeDistance, curve);
    }
    public void SetMoveTargetSecond()
    {
        curve = CalculateDashCurve(animation, 1);
        skillAnimation.startMove.AddListener(SetMoveOrigin);
        skillAnimation.startMove.RemoveListener(SetMoveTargetSecond);

        skillAnimation.SetMoveToTarget(targets[1].transform.position + Vector3.left * strikeDistance, curve);
    }
    public void SetMoveOrigin()
    {
        curve = CalculateDashCurve(animation, 2);

        skillAnimation.SetMoveToOrigin(curve);
        skillAnimation.startMove.RemoveListener(SetMoveOrigin);
    }
}
