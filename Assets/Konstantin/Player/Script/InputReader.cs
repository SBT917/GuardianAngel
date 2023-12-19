using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, Controls.IPlayerActions
{
    public Vector2 MouseDelta;
    public Vector2 MoveComposite;

    public float Altitude;

    public Action OnJumpPerformed;

    private Controls controls;

    private PlayerGrab playerGrab;

    private void OnEnable()
    {
        if (controls != null) return;
        controls = new Controls();
        controls.Player.SetCallbacks(this);
        controls.Player.Enable();

        TryGetComponent(out playerGrab);  
    }

    private void Start()
    {
        TimeManager.instance.onTimeCountZero += controls.Player.Disable;
    }

    public void OnDisable()
    {
        controls.Player.Disable();
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        MouseDelta = context.ReadValue<Vector2>();
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        MoveComposite = context.ReadValue<Vector2>();
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if(!context.performed) return;
        OnJumpPerformed?.Invoke();
    }
    public void OnUse(InputAction.CallbackContext context)
    {
        if (!context.performed) return;


        if(playerGrab.GrabbingObject == null)
        {
            playerGrab.Grab();
        }
        else
        {
            playerGrab.Release();
        }
    }
    public void OnFly(InputAction.CallbackContext context)
    {
        Altitude = context.ReadValue<float>();
    }
}
