using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SkillAnimationComponent : MonoBehaviour
{
    public UnityEvent skillActivation;
    
    // Moving to Target
    public UnityEvent startMove;
    public AnimationCurve curve;
    public float time = 0f;
    public Vector3 originalPos;
    private Vector3 startPos;
    private Vector3 targetPos;
    private Vector3 path;
    private bool moving = false;
    public void TriggerSkill()
    {
        skillActivation.Invoke();
    }
    public void StartMove()
    {
        moving = true;
        startMove.Invoke();
    }
    public void EndMove()
    {
        moving = false;
    }
    public void SetMoveToTarget(Vector3 _targetPos, AnimationCurve _curve)
    {
        time = 0;
        targetPos = _targetPos;
        curve = _curve;
        startPos = transform.position;
        path = targetPos - startPos;
    }
    public void SetMoveToOrigin(AnimationCurve _curve)
    {
        SetMoveToTarget(originalPos, _curve);
    }
    public void CreateParticleEffect(SkillEffectData skillEffect)
    {
        //Setting up particle
        GameObject particle = Instantiate(skillEffect.particle, gameObject.transform.position + skillEffect.offset, Quaternion.identity);
        //EndEffectSprite endEffectSprite = particle.GetComponent<EndEffectSprite>();
        //AnimationOverride.SetAnimationClip(endEffectSprite.animator, endEffectSprite.animatorOverrideController, endEffectSprite.baseCase, skillEffect.animation);

        //Changing Conditions
        if (skillEffect.isChild)
        {
            particle.transform.parent = gameObject.transform;
        }
        //if(skillEffect.xFlipped)
        //{
        //    particle.GetComponent<ParticleSystemRenderer>().flip = new Vector3(1, 0, 0);
        //}
        //if (skillEffect.yFlipped)
        //{
        //    particle.GetComponent<ParticleSystemRenderer>().flip = new Vector3(0, 1, 0);
        //}
        //particle.transform.localScale = particle.transform.localScale * skillEffect.scale;
    }
    private void Update()
    {
        if (moving)
        {
            time += Time.deltaTime;
            transform.position = startPos + (path * curve.Evaluate(time));
        }
    }
}
