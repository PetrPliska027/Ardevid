using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerGroundedState
{
    private Player player => (Player)entity;
    public PlayerJumpState(Player player, StateMachine stateMachine, string animNameBool) : base(player, stateMachine, animNameBool)
    {

    }

    public override void Enter()
    {
        base.Enter();
        player.SetVelocityY(player.jumpVelocity);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        xInput = player.inputHandler.NormalizedInputX;

        player.CheckIfShouldFlip(xInput);

        player.SetVelocityX(player.moveVelocity * xInput);

        if (player.CurrentVelocity.y < 0)
        {
            stateMachine.ChangeState(player.fallState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
