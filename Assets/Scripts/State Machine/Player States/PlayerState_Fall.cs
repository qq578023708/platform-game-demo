using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Data/States/PlayerStates/Fall", fileName = "PlayerState_Fall")]
public class PlayerState_Fall : PlayerState
{
    [SerializeField]AnimationCurve speedCurve;
    [SerializeField] float airMoveSpeed = 5f;

    public override void Enter()
    {
        base.Enter();
    }
    public override void LogicUpdate()
    {
        if (player.IsGround)
        {
            stateMachine.SwitchState(typeof(PlayerState_Land));
        }


        if (input.Jump)
        {
            if (player.CanAirJump)
            {
                stateMachine.SwitchState(typeof(PlayerState_AirJump));
                return;
            }
            input.SetJumpInputBuff();
        }
    }

    public override void PhysicUpdate()
    {
        player.SetVelocityY( speedCurve.Evaluate(stateDuration));
        player.Move(airMoveSpeed);
    }
}
