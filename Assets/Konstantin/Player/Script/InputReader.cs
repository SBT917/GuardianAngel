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

    private IGrabbable grabbingObject;

    public Action OnJumpPerformed;

    private Controls controls;


    private void OnEnable()
    {
        if (controls != null) return;
        controls = new Controls();
        controls.Player.SetCallbacks(this);
        controls.Player.Enable();
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


        if(grabbingObject == null)
        {
            RaycastHit hit;
            Vector3 pos = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            Debug.DrawRay(pos, transform.TransformDirection(Vector3.forward) * 2.0f, Color.red);
            if (Physics.Raycast(pos, transform.TransformDirection(Vector3.forward), out hit, 2.0f))
            {
                if (hit.transform.TryGetComponent(out IGrabbable grabbable))
                {
                    grabbable.Grabbed(transform);
                    grabbingObject = grabbable;
                }
            }
        }
        else
        {
            grabbingObject.Release(transform);
            grabbingObject = null;
        }
    }
    public void OnFly(InputAction.CallbackContext context)
    {
        Altitude = context.ReadValue<float>();
    }
}
