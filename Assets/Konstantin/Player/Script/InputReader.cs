using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, Controls.IPlayerActions
{
    public Vector2 mouseDelta;
    public Vector2 moveComposite;
    public Action onJumpPerformed;
    private Controls _controls;

    private void OnEnable()
    {
        if (_controls == null) return;
        _controls = new Controls();
        _controls.Player.SetCallbacks(this);
        _controls.Player.Enable();
    }
    public void OnDisable()
    { 
        _controls.Player.Disable();
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        moveComposite = context.ReadValue<Vector2>();
    }    
    public void OnJump(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        onJumpPerformed?.Invoke();
    }
}
