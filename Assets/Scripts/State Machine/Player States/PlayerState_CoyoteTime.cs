using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/States/PlayerStates/CoyoteTime", fileName = "PlayerState_CoyoteTime")]
public class PlayerState_CoyoteTime : PlayerState
{

    [SerializeField] float runSpeed = 5f;
    [SerializeField] float acceleration = 20f;
    [SerializeField] float coyoteTime = 0.1f;
    public override void Enter()
    {
        base.Enter();
        player.SetUseGravity(false);
    }

    public override void Exit()
    {
        player.SetUseGravity(true);
    }

    public override void LogicUpdate()
    {
        
        if (input.Jump)
        {
            stateMachine.SwitchState(typeof(PlayerState_JumpUp));
        }

        if (stateDuration>coyoteTime || !input.Move)
        {
            stateMachine.SwitchState(typeof(PlayerState_Fall));
        }
        
    }

    public override void PhysicUpdate()
    {

        player.Move(runSpeed);
    }
}
