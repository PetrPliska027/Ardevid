using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour, IInteractable
{
    private SplineFollower splineFollower;
    private Player player;
    protected int yInput;

    private void Awake()
    {
        splineFollower = GetComponent<SplineFollower>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player = collision.gameObject.GetComponent<Player>();
        collision.gameObject.transform.SetParent(transform);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player = null;
            collision.gameObject.transform.SetParent(null);
        }
    }

    private void Update()
    {
        if (player != null)
        {
            yInput = player.InputHandler.NormalizedInputY;

            if (yInput == 1)
            {
                MoveElevatorUp();
            }
            else if (yInput == -1)
            {
                MoveElevatorDown();
            }
        }
    }

    public void StartElevator()
    {
        splineFollower.follow = true;
    }

    public void StopElevator()
    {
        splineFollower.follow = false;
    }

    public void MoveElevatorUp()
    {
        splineFollower.direction = Spline.Direction.Forward;
        StartElevator();
    }

    public void MoveElevatorDown()
    {
        splineFollower.direction = Spline.Direction.Backward;
        StartElevator();
    }

    public void Interact()
    {
        
    }
}
