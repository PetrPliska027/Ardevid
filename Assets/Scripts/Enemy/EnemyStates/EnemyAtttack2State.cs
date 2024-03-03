using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class EnemyAttack2State : State
{
    private Enemy enemy => (Enemy)entity;
    public EnemyAttack2State(Enemy enemy, StateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {

    }

    public override void Enter()
    {
        base.Enter();
        enemy.SetVelocityX(0);
        enemy.Attack();
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
            stateMachine.ChangeState(enemy.attack1State);
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
