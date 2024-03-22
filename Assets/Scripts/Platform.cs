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

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.SetParent(transform);
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        other.transform.SetParent(null);
    }

    public void Interact()
    {
        splineFollower.follow = !splineFollower.follow;
    }
}
