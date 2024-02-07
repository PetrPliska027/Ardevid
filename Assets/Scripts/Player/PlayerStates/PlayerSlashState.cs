using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class PlayerSlashState : State
{
    protected bool attackPressed;
    private Player player => (Player)entity;
    public PlayerSlashState(Player player, StateMachine stateMachine, string animNameBool) : base(player, stateMachine, animNameBool)
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
        player.SetVelocityX(0);
        attackPressed = player.inputHandler.AttackInput;
        if (Time.time - startTime >= player.anim.GetCurrentAnimatorStateInfo(0).length)
        {
            stateMachine.ChangeState(player.idleState);
        }
        else if (attackPressed && Time.time - startTime <= player.timeToNextAttack)
        {
            player.inputHandler.UseAttackInput();
            if (startTime >= player.anim.GetCurrentAnimatorStateInfo(0).length)
            {
                stateMachine.ChangeState(player.stabState);
            }
                
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}

