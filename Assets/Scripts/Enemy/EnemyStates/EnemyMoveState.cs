using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : State
{
    private Enemy enemy => (Enemy)entity;
    public EnemyMoveState(Enemy enemy, StateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {

    }

    public override void Enter()
    {
        base.Enter();
        enemy.SetVelocityX(enemy.moveVelocity * enemy.facingDirection);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(!enemy.CheckCliff())
        {
            enemy.stateMachine.ChangeState(enemy.idleState);
        }
        else if (enemy.CheckWall())
        {
            enemy.stateMachine.ChangeState(enemy.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
