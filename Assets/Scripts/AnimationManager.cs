using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationManager : MonoBehaviour
{
    private const string Run = "IsRun";
    private const string RunObject = "RunObject";
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void IsRun()
    {
        _animator.SetBool(Run, true);
        _animator.SetBool(RunObject, false);
    }

    public void Idle()
    {
        _animator.SetBool(Run, false);
        _animator.SetBool(RunObject, false);
    }

    public void RunningObjects()
    {
        _animator.SetBool(RunObject, true);
        _animator.SetBool(Run, false);
    }
}
