using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class EnemyAttack1State : State
{
    private Enemy enemy => (Enemy)entity;
    public EnemyAttack1State(Enemy enemy, StateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
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
        if (Time.time - startTime >= enemy.anim.GetCurrentAnimatorStateInfo(0).length && enemy.CheckIfPlayerInAttackRange())
        {
            stateMachine.ChangeState(enemy.attack2State);
        }
        else if (!enemy.CheckIfPlayerInAttackRange())
        {
            stateMachine.ChangeState(enemy.chaseState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
