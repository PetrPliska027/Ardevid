using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : State
{
    protected int xInput;
    protected bool jumpPressed;

    private Player player => (Player)entity;
    public PlayerGroundedState(Player player, StateMachine stateMachine, string animNameBool) : base(player, stateMachine, animNameBool)
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
        
        xInput = player.inputHandler.NormalizedInputX;

        jumpPressed = player.inputHandler.JumpInput;
  
        if(jumpPressed && player.CheckIfTouchingGround()) 
        {
            player.inputHandler.UseJumpInput();
            stateMachine.ChangeState(player.jumpState);
        }
        else if (!player.CheckIfTouchingGround())
        {
            stateMachine.ChangeState(player.fallState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
