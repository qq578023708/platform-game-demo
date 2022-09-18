using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/States/PlayerStates/JumpUp", fileName = "PlayerState_JumpUp")]
public class PlayerState_JumpUp : PlayerState
{
    [SerializeField]float jumpForce = 7f;
    [SerializeField]float airMoveSpeed = 5f;
    [SerializeField] ParticleSystem jumpVFX;
    [SerializeField]AudioClip jumpSFX;
    public override void Enter()
    {
        base.Enter();
        input.JumpInputBuff = false;
        player.playerVoice.PlayOneShot(jumpSFX);
        player.SetVelocityY(jumpForce);
        Instantiate(jumpVFX,player.transform.position,Quaternion.identity);
    }

    public override void LogicUpdate()
    {
        if (input.StopJump || player.IsFalling)
        {
            stateMachine.SwitchState(typeof(PlayerState_Fall));
        }
    }

    public override void PhysicUpdate()
    {
        player.Move(airMoveSpeed);
    }
}
