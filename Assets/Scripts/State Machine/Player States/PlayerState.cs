using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : ScriptableObject, IState
{
    protected Animator animator;
    protected PlayerStateMachine stateMachine;
    protected PlayerInput input;
    protected PlayerController player;
    protected float currentSpeed;
    [SerializeField]string stateName;
    int stateHashCode;
    [SerializeField,Range(0f,1f)]float transitionDuration = 0.1f;
    float stateStartTime;
    protected bool IsAnimationFinish => stateDuration >= animator.GetCurrentAnimatorStateInfo(0).length;
    protected float stateDuration => Time.time - stateStartTime;
    private void OnEnable()
    {
        stateHashCode=Animator.StringToHash(stateName);
    }
    public void Initlize(Animator animator,PlayerInput input,PlayerController player,PlayerStateMachine playerStateMachine)
    {
        this.animator = animator;
        this.stateMachine = playerStateMachine;
        this.input = input;
        this.player = player;
    }
    public virtual void Enter()
    {
        animator.CrossFade(stateHashCode, transitionDuration);
        stateStartTime = Time.time;
    }

    public virtual void Exit()
    {
        
    }

    public virtual void LogicUpdate()
    {
        
    }

    public virtual void PhysicUpdate()
    {
        
    }
}
