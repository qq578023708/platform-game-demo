using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/States/PlayerStates/Land", fileName = "PlayerState_Land")]
public class PlayerState_Land : PlayerState
{
    [SerializeField]float stiffTime = 0.2f;
    public override void Enter()
    {
        base.Enter();
        player.SetVelocity(Vector3.zero);
    }
    public override void LogicUpdate()
    {
        if (player.IsVictory)
        {
            stateMachine.SwitchState(typeof(PlayerState_Victory));
        }
        if (input.JumpInputBuff || input.Jump)
        {
            input.JumpInputBuff = false;
            stateMachine.SwitchState(typeof(PlayerState_JumpUp));
        }

        if (stateDuration < stiffTime)
        {
            return;
        }

        if (input.Move)
        {
            stateMachine.SwitchState(typeof(PlayerState_Run));
        }

        if (IsAnimationFinish)
        {
            stateMachine.SwitchState(typeof(PlayerState_Idle));
        }
    }
}
