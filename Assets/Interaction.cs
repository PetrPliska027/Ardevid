using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour, IInteractable
{
    [SerializeField] private List<GameObject> interactablesGameObjects;
    [SerializeField] protected Player player;
    protected bool interactPressed;

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
            interactPressed = player.InputHandler.InteractInput;
            Debug.Log(interactPressed);

            if (interactPressed)
            {
                Interact();
                player.InputHandler.UseInteractInput();
            }
        }
    }

    public void Interact()
    {
        foreach (var interactableGameObject in interactablesGameObjects)
        {
            var interactable = interactableGameObject.GetComponent<IInteractable>();
            if (interactable == null) continue;
            interactable.Interact();
        }
    }
}
