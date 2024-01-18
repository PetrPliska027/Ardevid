using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public StateMachine stateMachine;

    public int facingDirection { get; private set; }
    public Rigidbody2D rb { get; private set; }
    public Animator anim { get; private set; }

    [HideInInspector] public Vector2 CurrentVelocity { get; private set; }

    [SerializeField] private Vector2 workspace;

    public virtual void Awake()
    {
        stateMachine = new StateMachine();
    }

    public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        facingDirection = 1;
    }

    public virtual void Update()
    {
        CurrentVelocity = rb.velocity;
        stateMachine.currentState.LogicUpdate();
    }

    public virtual void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
    }

    public virtual void SetVelocityX(float velocity)
    {
        workspace.Set(velocity, CurrentVelocity.y);
        rb.velocity = workspace;
        CurrentVelocity = workspace;
    }

    public virtual void SetVelocityY(float velocity)
    {
        workspace.Set(CurrentVelocity.x, velocity);
        rb.velocity = workspace;
        CurrentVelocity = workspace;
    }

    public void CheckIfShouldFlip(int xInput)
    {
        if (xInput != 0 && xInput != facingDirection)
            Flip();
    }

    public void Flip()
    {
        facingDirection *= -1;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }
}
