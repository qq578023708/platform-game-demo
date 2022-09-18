using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/States/PlayerStates/Death", fileName = "PlayerState_Death")]
public class PlayerState_Death : PlayerState
{
    [SerializeField] ParticleSystem deathVFX;
    [SerializeField] AudioClip[] deathSFX;
    public override void Enter()
    {
        base.Enter();
        Instantiate(deathVFX,player.transform.position,Quaternion.identity);
        AudioClip clip = deathSFX[Random.Range(0, deathSFX.Length)];
        SFXPlayer.audioPlayer.PlayOneShot(clip);
    }

    public override void LogicUpdate()
    {
        if (IsAnimationFinish)
        {
            stateMachine.SwitchState(typeof(PlayerState_Float));
        }
    }
}
