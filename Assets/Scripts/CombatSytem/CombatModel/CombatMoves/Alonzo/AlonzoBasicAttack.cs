using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AlonzoBasicAttack : BasicAttack
{
    public AlonzoCombatUnit owner;
    private AnimationClip animation;
    public AlonzoBasicAttack (AlonzoCombatUnit _owner = null)
    {
        name = "Basic Attack";
        owner = _owner;
        targetAmount = 1;
        animation = Resources.Load<AnimationClip>("Animations/CombatSystem/Alonzo/AlonzoBasicAtk");
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
        Debug.Log("starting activatiion");
        owner.SetCharge(targets[0].element);
        Debug.Log("starting activatiion");
        user.ChangeMP(mpGain);
        Debug.Log("starting activatiion");
    }
}
