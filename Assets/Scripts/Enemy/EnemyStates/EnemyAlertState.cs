using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAlertState : State
{
    private Enemy enemy => (Enemy)entity;
    public EnemyAlertState(Enemy enemy, StateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {

    }

    public override void Enter()
    {
        base.Enter();
        enemy.SetVelocityX(0);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(Time.time - startTime >= 1.2f)
        {
            stateMachine.ChangeState(enemy.chaseState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
