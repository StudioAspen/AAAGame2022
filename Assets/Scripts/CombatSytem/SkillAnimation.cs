using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SkillAnimation : MonoBehaviour
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
        skillActivation.RemoveAllListeners();
    }
    public void StartMove()
    {
        moving = true;
        startMove.Invoke();
        //startMove.RemoveAllListeners();
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
    private void Update()
    {
        if (moving)
        {
            time += Time.deltaTime;
            transform.position = startPos + (path * curve.Evaluate(time));
        }
    }
}
