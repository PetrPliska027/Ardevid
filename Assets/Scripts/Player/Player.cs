using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    public PlayerFallState fallState { get; private set; }
    public PlayerSlashState slashState { get; private set; }
    public PlayerStabState stabState { get; private set; }
    public PlayerSlamState slamState { get; private set; }
    public PlayerDeathState deathState { get; private set; }

    private Health playerHealth;

    [Header("Movement Settings")]
    public float moveVelocity = 10f;
    public float jumpVelocity = 10f;

    public PlayerInputHandler inputHandler { get; private set; }

    [Header("Attack Settings")]
    [SerializeField]
    private Transform attackPoint;
    [SerializeField]
    private float attackRadius = 5f;
    public float timeToNextAttack = 0.7f;
    [SerializeField]
    private float damage = 25f;

    [Header("Ground System")]
    [SerializeField] private Transform groundedCheck;
    [SerializeField] private Vector2 groundedCheckScale;
    [SerializeField] private LayerMask groundMask;

    private void OnEnable()
    {
        playerHealth.OnDie += OnDie;
    }

    private void OnDisable()
    {
        playerHealth.OnDie -= OnDie;
    }

    public override void Awake()
    {
        base.Awake();

        idleState = new PlayerIdleState(this, stateMachine, "idle");
        moveState = new PlayerMoveState(this, stateMachine, "move");
        jumpState = new PlayerJumpState(this, stateMachine, "jump");
        fallState = new PlayerFallState(this, stateMachine, "fall");
        slashState = new PlayerSlashState(this, stateMachine, "attack1");
        stabState = new PlayerStabState(this, stateMachine, "attack2");
        slamState = new PlayerSlamState(this, stateMachine, "attack3");
        deathState = new PlayerDeathState(this, stateMachine, "death");

        playerHealth = GetComponent<Health>();
        inputHandler = GetComponent<PlayerInputHandler>();
    }

    public override void Start()
    {
        base.Start();

        stateMachine.Initialize(idleState);
    }

    public override void Update()
    {
        base.Update();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void SetVelocityX(float velocity)
    {
        base.SetVelocityX(velocity);
    }

    public override void SetVelocityY(float velocity)
    {
        base.SetVelocityY(velocity);
    }

    public void InteractWithObject()
    {
        Debug.Log("Interact");
    }

    public bool CheckIfTouchingGround()
    {
        return Physics2D.OverlapBox(groundedCheck.position, groundedCheckScale, 0, groundMask);
    }

    public void Attack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius);
        foreach (Collider2D collider in colliders)
        {
            Health health = collider.GetComponent<Health>();
            if (health != null && playerHealth.team != health.team)
            {
                Debug.Log($"{name} attacked {health.name} with {damage} damage!");
                health.DealDamage(damage, gameObject);
            }
        }
    }

    private void OnDie(Health target, GameObject attacker)
    {
        Debug.Log($"{name} died");
        this.enabled = false;
        stateMachine.ChangeState(deathState);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(groundedCheck.position, groundedCheckScale);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }
}
