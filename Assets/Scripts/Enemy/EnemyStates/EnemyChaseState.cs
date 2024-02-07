using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class EnemyChaseState : State
{
    private Enemy enemy => (Enemy)entity;
    public EnemyChaseState(Enemy enemy, StateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {

    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        Vector2 targetDirection = (enemy.playerTransform.position - enemy.transform.position).normalized;

        int direction = (int)Mathf.Sign(targetDirection.x);

        if(direction != enemy.facingDirection)
            enemy.Flip();

        enemy.SetVelocityX(direction * enemy.moveVelocity);

        if (enemy.CheckIfPlayerInAttackRange())
        {
            stateMachine.ChangeState(enemy.attack1State);
        }
        else if (enemy.CheckCliff() || enemy.CheckWall()) 
        {
            Debug.Log("dw"+enemy.CheckCliff());
            Debug.Log(enemy.CheckWall());
            stateMachine.ChangeState(enemy.moveState);
        }
        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
