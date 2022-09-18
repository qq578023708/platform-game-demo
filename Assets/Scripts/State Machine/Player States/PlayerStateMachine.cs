using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    Animator animator;
    public PlayerState[] states;
    PlayerInput input;
    PlayerController player;
    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        statesTable=new Dictionary<System.Type, IState>(states.Length);
        input=GetComponent<PlayerInput>();
        player=GetComponent<PlayerController>();
        foreach(PlayerState state in states)
        {
            state.Initlize(animator,input,player,this);
            statesTable.Add(state.GetType(),state);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        SwitchOn(statesTable[typeof(PlayerState_Idle)]);
    }
}
