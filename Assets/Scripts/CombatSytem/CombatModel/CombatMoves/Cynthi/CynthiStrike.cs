using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CynthiStrike : CynthiSkill
{
    public CynthiStrike()
    {
        name = "Cynthi Strike";
        mpCost = 0f;
        targetAmount = 1;
        animation = Resources.Load<AnimationClip>("Animations/CombatSystem/Cynthi/CynthiStrike");
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
        user.ChangeMP(-mpCost);

        skillAnimation.skillActivation.RemoveListener(ActivateSkill);
    }
    public void SetMoveTarget()
    {
        curve = CalculateDashCurve(animation, 0);
        skillAnimation.startMove.AddListener(SetMoveTargetOrigin);
        skillAnimation.startMove.RemoveListener(SetMoveTarget);

        skillAnimation.SetMoveToTarget(targets[0].transform.position + Vector3.right, curve);
    }
    public void SetMoveTargetOrigin()
    {
        curve = CalculateDashCurve(animation, 1);

        skillAnimation.SetMoveToOrigin(curve);
        skillAnimation.startMove.RemoveListener(SetMoveTargetOrigin);
    }
}
