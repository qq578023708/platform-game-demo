using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    PlayerInputActions inputActions;
    public bool JumpInputBuff { get; set; }
    [SerializeField] float jumpInputBuffTime = 0.2f;
    WaitForSeconds waitJumpInputBuff;
    public bool Jump => inputActions.GamePlay.Jump.WasPressedThisFrame();
    public bool StopJump => inputActions.GamePlay.Jump.WasReleasedThisFrame();
    public bool Move => AxesX != 0f;
    public Vector2 Axes => inputActions.GamePlay.Axes.ReadValue<Vector2>();
    public float AxesX => Axes.x;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
        waitJumpInputBuff = new WaitForSeconds(jumpInputBuffTime);
    }

    public void EnableGamePlayInput()
    {
        inputActions.GamePlay.Enable();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(1, 1, 200, 20), $"JumpInputBuff:{JumpInputBuff}");
    }

    public void SetJumpInputBuff()
    {
        StopCoroutine(nameof(JumpInputBuffCoroutine));
        StartCoroutine(nameof(JumpInputBuffCoroutine));
    }

    IEnumerator JumpInputBuffCoroutine()
    {
        JumpInputBuff = true;
        yield return waitJumpInputBuff;
        JumpInputBuff = false;
    }

    public void DisableGamePlayInput()
    {
        inputActions.GamePlay.Disable();
    }
}
