using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightShadeAura : AlonzoSkill
{
    public NightShadeAura(AlonzoCombatUnit _owner = null)
    {
        name = "NightSade Aura";
        owner = _owner;
        mpCost = 30f;
        targetAmount = -1;
        animation = Resources.Load<AnimationClip>("Animations/CombatSystem/Alonzo/AlonzoNightShade");
    }

    public override void UseMove(List<CombatUnit> _targets, CombatUnit _user)
    {
        targets = new List<CombatUnit>(_targets);
        user = _user;

        skillAnimation = user.GetComponent<SkillAnimationComponent>();
        skillAnimation.skillActivation.AddListener(ActivateSkill);

        //Setting Animation
        Animator animator = user.GetComponent<Animator>();
        AnimationOverride.SetAnimationClip(animator, overrideController, "BaseCase", animation);
    }
    public void ActivateSkill()
    {
        foreach (CombatUnit target in targets)
        {
            target.TakeDamage(user.currentStats.attack);
        }
        user.ChangeMP(-mpCost);

        skillAnimation.skillActivation.RemoveListener(ActivateSkill);
    }
}
