using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/States/PlayerStates/Victory", fileName = "PlayerState_Victory")]
public class PlayerState_Victory : PlayerState
{
    [SerializeField] AudioClip[] victoryClip;
    public override void Enter()
    {
        base.Enter();
        input.DisableGamePlayInput();
        AudioClip clip= victoryClip[Random.Range(0,victoryClip.Length)];
        SFXPlayer.audioPlayer.PlayOneShot(clip);
    }
}
