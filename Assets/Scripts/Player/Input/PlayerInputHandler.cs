using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 RawMoveInput { get; private set; }
    public int NormalizedInputX { get; private set; }
    public int NormalizedInputY { get; private set; }
    public bool JumpInput { get; private set; }
    public bool InteractInput { get; private set; }
    public bool AttackInput { get; private set; }
    public bool CancelInput { get; private set; }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        RawMoveInput = context.ReadValue<Vector2>();

        NormalizedInputX = (int)(RawMoveInput * Vector2.right).normalized.x;
        NormalizedInputY = (int)(RawMoveInput * Vector2.up).normalized.y;
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            JumpInput = true;
        }
    }

    public void UseJumpInput() => JumpInput = false;

    public void OnInteractInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            InteractInput = true;
        }
    }

    public void UseInteractInput() => InteractInput = false;

    public void OnAttackInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            AttackInput = true;
        }
    }

    public void UseAttackInput() => AttackInput = false;

    public void OnCancelInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            CancelInput = true;
        }
    }
    public void UseCancelInput() => CancelInput = false;
}
