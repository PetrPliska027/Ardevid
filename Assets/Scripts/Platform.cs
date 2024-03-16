using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour, IInteractable
{
    private SplineFollower splineFollower;

    private void Awake()
    {
        splineFollower = GetComponent<SplineFollower>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }

    public void Interact()
    {
        splineFollower.follow = !splineFollower.follow;
    }
}
