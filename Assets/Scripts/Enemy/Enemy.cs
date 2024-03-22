using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : Entity
{
    // Add States
    public EnemyIdleState idleState { get; private set; }
    public EnemyMoveState moveState { get; private set; }
    public EnemyAlertState alertState { get; private set; }
    public EnemyChaseState chaseState { get; private set; }
    public EnemyAttack1State attack1State { get; private set; }
    public EnemyAttack2State attack2State { get; private set; }
    public EnemyDeathState deathState { get; private set; }

    private Health enemyHealth;

    public float moveVelocity = 10f;
    [HideInInspector] public float idleTime;
    [SerializeField] private float idleTimeMin = 1f;
    [SerializeField] private float idleTimeMax = 3f;
    public float alertTime = 3f;

    [SerializeField] private Transform cliffCheck;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private float cliffCheckDistance;
    [SerializeField] private float wallCheckDistance;
    [SerializeField] private LayerMask groundMask;

    [SerializeField] LayerMask playerMask;
    [SerializeField] float agroRadius = 7;
    [SerializeField] float attackRadius = 0.5f;
    [SerializeField] Vector2 attackPosition;
    [SerializeField] float damage;

    [HideInInspector] public Transform playerTransform;

    [SerializeField] private GameObject XPOrbPrefab;

    public override void Awake()
    {
        base.Awake();

        // Add States
        idleState = new EnemyIdleState(this, stateMachine, "idle");
        moveState = new EnemyMoveState(this, stateMachine, "move");
        alertState = new EnemyAlertState(this, stateMachine, "idle");
        chaseState = new EnemyChaseState(this, stateMachine, "move");
        attack1State = new EnemyAttack1State(this, stateMachine, "attack1");
        attack2State = new EnemyAttack2State(this, stateMachine, "attack2");
        deathState = new EnemyDeathState(this, stateMachine, "death");

        enemyHealth = GetComponent<Health>();
    }

    public override void Start()
    {
        base.Start();

        stateMachine.Initialize(moveState);

        playerTransform = FindObjectOfType<Player>().GetComponent<Transform>();
    }

    private void OnEnable()
    {
        health.OnDie += OnDie;
    }

    private void OnDisable()
    {
        health.OnDie -= OnDie;
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

    public bool CheckWall()
    {
        return Physics2D.Raycast(cliffCheck.position, transform.right, cliffCheckDistance, groundMask);
    }

    public bool CheckCliff()
    {
        return !Physics2D.Raycast(wallCheck.position, Vector2.down, wallCheckDistance, groundMask);
    }

    public bool CheckPlayer()
    {
        return Physics2D.Raycast(transform.position, transform.right, agroRadius, playerMask);
    }

    public bool CheckIfPlayerInAttackRange()
    {
        return Physics2D.OverlapCircle(transform.position, attackRadius, playerMask);
    }

    public void SetRandomIdleTime()
    {
        idleTime = Random.Range(idleTimeMin, idleTimeMax);
    }

    public void Attack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll((transform.position + (Vector3)(attackPosition * facingDirection)), attackRadius);
        foreach (Collider2D collider in colliders)
        {
            Health health = collider.GetComponent<Health>();
            if (enemyHealth != null && enemyHealth.team != health.team)
            {
                Debug.Log($"{name} attacked {health.name} with {damage} damage!");
                health.DealDamage(damage, gameObject);
            }  
        }
    }

    private void OnDie(Health target, GameObject attacker)
    {
        stateMachine.ChangeState(deathState);
        Instantiate(XPOrbPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject, 2f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(wallCheck.position, wallCheck.position + (Vector3)(Vector2.right * facingDirection * wallCheckDistance));
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(cliffCheck.position, cliffCheck.position + (Vector3)(Vector2.down * cliffCheckDistance));
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere((transform.position + (Vector3)(attackPosition * facingDirection)), attackRadius);
    }
}
