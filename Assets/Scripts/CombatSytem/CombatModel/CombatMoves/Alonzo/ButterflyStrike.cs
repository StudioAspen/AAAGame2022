using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyStrike : AlonzoSkill
{
    public ButterflyStrike(AlonzoCombatUnit _owner = null)
    {
        name = "Butterfly Strike";
        owner = _owner;
        mpCost = 25f;
        targetAmount = 1;
        animation = Resources.Load<AnimationClip>("Animations/CombatSystem/Alonzo/AlonzoButterflyStrike");
    }

    public override void UseMove(List<CombatUnit> _targets, CombatUnit _user)
    {
        targets = new List<CombatUnit>(_targets);
        user = _user;

        skillAnimation = user.GetComponent<SkillAnimationComponent>();
        skillAnimation.skillActivation.AddListener(FirstStrike);

        //Setting up target movement
        Vector3 holder = user.transform.position;
        skillAnimation.originalPos = new Vector3(holder.x, holder.y, holder.z);
        skillAnimation.startMove.AddListener(SetMoveTargetFirst);

        //Setting Animation
        Animator animator = user.GetComponent<Animator>();
        AnimationOverride.SetAnimationClip(animator, overrideController, "BaseCase", animation);
    }

    public void FirstStrike()
    {
        targets[0].TakeDamage(user.currentStats.attack);
        targets[0].AddElementStatus(new ElementStatus(owner.charge, owner));

        skillAnimation.skillActivation.AddListener(SecondStrike);
        skillAnimation.skillActivation.RemoveListener(FirstStrike);
    }
    public void SecondStrike()
    {
        targets[0].TakeDamage(user.currentStats.attack);
        targets[0].AddElementStatus(new ElementStatus(owner.charge, owner));

        owner.SetCharge(Element.NONE);
        user.ChangeMP(-mpCost);

        skillAnimation.skillActivation.RemoveListener(SecondStrike);
    }
    public void SetMoveTargetFirst()
    {
        curve = CalculateDashCurve(animation, 0);
        skillAnimation.startMove.AddListener(SetMoveOrigin);
        skillAnimation.startMove.RemoveListener(SetMoveTargetFirst);

        skillAnimation.SetMoveToTarget(targets[0].transform.position + Vector3.left, curve);
    }
    public void SetMoveOrigin()
    {
        curve = CalculateDashCurve(animation, 1);

        skillAnimation.SetMoveToOrigin(curve);
        skillAnimation.startMove.RemoveListener(SetMoveOrigin);
    }
}
