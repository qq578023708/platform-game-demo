using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerInput playerInput;
    new Rigidbody rigidbody;
    PlayerOnGroundDetect groundDetect;
    [SerializeField] VoidEventChannel levelClearEvent;
    public bool IsVictory { get; private set; }
    public float MoveSpeed => Mathf.Abs(rigidbody.velocity.x);
    public bool IsGround=>groundDetect.IsGround;
    public bool IsFalling => rigidbody.velocity.y <= 0 && !IsGround;

    public bool CanAirJump { get; set; }
    public AudioSource playerVoice { get; private set; }
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        rigidbody=GetComponent<Rigidbody>();
        groundDetect=GetComponentInChildren<PlayerOnGroundDetect>();
        playerVoice=GetComponentInChildren<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        playerInput.EnableGamePlayInput();
    }

    private void OnEnable()
    {
        levelClearEvent.AddListener(OnLevelClear);
    }

    private void OnDisable()
    {
        levelClearEvent.removeListener(OnLevelClear);
    }

    void OnLevelClear()
    {
        IsVictory = true;
    }

    public void Move(float speed)
    {
        if (playerInput.Move)
        {
            transform.localScale = new Vector3(playerInput.AxesX,1,1);
        }
        SetVelocityX(speed * playerInput.AxesX);
    }
    public void SetVelocity(Vector3 velocity)
    {
        rigidbody.velocity = velocity;
    }

    public void SetVelocityX(float velocityX)
    {
        rigidbody.velocity = new Vector3(velocityX,rigidbody.velocity.y);
    }

    public void SetVelocityY(float velocityY)
    {
        rigidbody.velocity = new Vector3(rigidbody.velocity.x, velocityY);
    }

    public void SetUseGravity(bool useGravity)
    {
        rigidbody.useGravity = useGravity;
    }

    internal void OnDeath()
    {
        playerInput.DisableGamePlayInput();
        SetVelocity(Vector3.zero);
        SetUseGravity(false);
        rigidbody.detectCollisions = false;
        GetComponent<StateMachine>().SwitchState(typeof(PlayerState_Death));
    }
}
