using System;
using UnityEngine;
using UnityEngine.InputSystem.XInput;

public class Fountain : MonoBehaviour
{
    public static event Action OnSkillTreeInteracted;
    public static event Action OnSkillTreeInteractEnded;
    protected Player player;
    protected bool interactPressed;
    protected bool cancelPressed;
    protected int xInput;

    private bool resting;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player = collision.gameObject.GetComponent<Player>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player = null;
        }
    }

    private void Update()
    {
        if (player != null)
        {
            interactPressed = player.inputHandler.InteractInput;
            cancelPressed = player.inputHandler.CancelInput;
            xInput = player.inputHandler.NormalizedInputX;

            if (interactPressed && resting == false)
            {
                player.inputHandler.UseInteractInput();
                OnSkillTreeInteracted?.Invoke();
                resting = true;
            }
            if (cancelPressed || xInput != 0 && resting)
            {
                player.inputHandler.UseCancelInput();
                OnSkillTreeInteractEnded?.Invoke();
                resting = false;
            }
        }
    }
}
