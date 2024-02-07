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

    public float moveVelocity = 10f;
    public float idleTime;
    [SerializeField] private float idleTimeMin = 1f;
    [SerializeField] private float idleTimeMax = 3f;

    [SerializeField] private Transform cliffCheck;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private float cliffCheckDistance;
    [SerializeField] private float wallCheckDistance;
    [SerializeField] private LayerMask groundMask;

    [SerializeField] LayerMask enemyMask;
    [SerializeField] LayerMask playerMask;
    [SerializeField] float agroRadius = 7;
    [SerializeField] float attackRadius = 0.5f;

    public Transform playerTransform;

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
    }

    public override void Start()
    {
        base.Start();

        stateMachine.Initialize(moveState);

        playerTransform = FindObjectOfType<Player>().GetComponent<Transform>();
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(wallCheck.position, wallCheck.position + (Vector3)(Vector2.right * facingDirection * wallCheckDistance));
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(cliffCheck.position, cliffCheck.position + (Vector3)(Vector2.down * cliffCheckDistance));
    }
}
