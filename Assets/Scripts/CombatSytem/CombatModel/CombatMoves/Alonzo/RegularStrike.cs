using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RegularStrike : AlonzoSkill
{
    private AnimationClip animation;
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

        user.GetComponent<SkillAnimation>().skillActivation.RemoveAllListeners();
        user.GetComponent<SkillAnimation>().skillActivation.AddListener(ActivateSkill);

        //Setting Animation
        overrideController = AnimationOverride.SetAnimationClip(overrideController, "BaseCase", animation);
        Animator animator = user.GetComponent<Animator>();
        animator.runtimeAnimatorController = overrideController;
    }
    public void ActivateSkill()
    {
        targets[0].TakeDamage(user.currentStats.attack);
        targets[0].AddElementStatus(new ElementStatus(owner.charge, owner));

        owner.SetCharge(Element.NONE);
        user.ChangeMP(-mpCost);
    }
}
