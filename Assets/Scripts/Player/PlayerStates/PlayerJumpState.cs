using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerGroundedState
{
    public PlayerJumpState(Player player, PlayerStateMachine playerStateMachine, string animNameBool) : base(player, playerStateMachine, animNameBool)
    {

    }

    public override void DoChecks()
    {
        base.DoChecks();
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

        xInput = player.InputHandler.NormalizedInputX;

        player.CheckIfShouldFlip(xInput);

        player.SetVelocityX(player.moveVelocity * xInput);

        if (player.CurrentVelocity.y < 0)
        {
            playerStateMachine.ChangeState(player.FallState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
