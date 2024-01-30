using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour, IDamageable
{
    public StateMachine stateMachine;

    public int facingDirection { get; private set; }
    public Rigidbody2D rb { get; private set; }
    public Animator anim { get; private set; }

    [SerializeField] protected float health = 100;
    public float Health
    {
        get { return health; }
        set { health = value; }
    }

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

    public virtual void Die()
    {
        Debug.Log($"{gameObject.name} died!");
    }

    public void Damage(float damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Die();
        }
    }
}
