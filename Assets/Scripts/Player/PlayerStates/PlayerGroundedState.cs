using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    protected int xInput;
    protected bool jumpPressed;
    public PlayerGroundedState(Player player, PlayerStateMachine playerStateMachine, string animNameBool) : base(player, playerStateMachine, animNameBool)
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

        xInput = player.InputHandler.NormalizedInputX;

        jumpPressed = player.InputHandler.JumpInput;
  
        if(jumpPressed && player.CheckIfTouchingGround()) 
        {
            player.InputHandler.UseJumpInput();
            playerStateMachine.ChangeState(player.JumpState);
        }
        else if (!player.CheckIfTouchingGround())
        {
            playerStateMachine.ChangeState(player.FallState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }
}
