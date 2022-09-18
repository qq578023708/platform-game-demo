using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Data/States/PlayerStates/Float", fileName = "PlayerState_Float")]
public class PlayerState_Float : PlayerState
{
    [SerializeField] VoidEventChannel deathEvent;
    [SerializeField] ParticleSystem floatVFX;
    [SerializeField] Vector3 floatingPositionOffset;
    [SerializeField] float floatingSpeed = 0.5f;
    [SerializeField] Vector3 vfxPositionOffset;
    Vector3 floatingPosition;
    public override void Enter()
    {
        base.Enter();
        deathEvent.Boardcast();
        Vector3 vfxPosition =player.transform.position+new Vector3(player.transform.localScale.x*vfxPositionOffset.x,vfxPositionOffset.y);
        floatingPosition=player.transform.position+floatingPositionOffset;
        Instantiate(floatVFX, vfxPosition, Quaternion.identity,player.transform);
    }

    public override void LogicUpdate()
    {
        if (Vector3.Distance(player.transform.position, floatingPosition) > floatingSpeed * Time.deltaTime)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, floatingPosition,floatingSpeed*Time.deltaTime);
        }
        else
        {
            floatingPosition += (Vector3)Random.insideUnitCircle;
        }
    }
}
