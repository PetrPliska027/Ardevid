using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : State
{
    private Enemy enemy => (Enemy)entity;
    public EnemyIdleState(Enemy enemy, StateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {

    }

    public override void Enter()
    {
        base.Enter();
        enemy.SetVelocityX(0f);
        enemy.SetRandomIdleTime();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(Time.time >= startTime + enemy.idleTime)
        {
            entity.Flip();
            enemy.stateMachine.ChangeState(enemy.moveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
