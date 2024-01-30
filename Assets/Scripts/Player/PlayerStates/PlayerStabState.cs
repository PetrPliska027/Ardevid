using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class PlayerStabState : PlayerGroundedState
{
    private Player player => (Player)entity;
    public PlayerStabState(Player player, StateMachine stateMachine, string animNameBool) : base(player, stateMachine, animNameBool)
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

        attackPressed = player.inputHandler.AttackInput;

        if (attackPressed && Time.time - startTime <= player.timeToNextAttack)
        {
            player.inputHandler.UseAttackInput();
            stateMachine.ChangeState(player.slamState);
        }

        stateMachine.ChangeState(player.idleState);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}

