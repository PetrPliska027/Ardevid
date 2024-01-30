using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : State
{
    protected int xInput;
    protected bool jumpPressed;
    protected bool attackPressed;
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

        attackPressed = player.inputHandler.AttackInput;
  
        if(jumpPressed && player.CheckIfTouchingGround()) 
        {
            player.inputHandler.UseJumpInput();
            stateMachine.ChangeState(player.jumpState);
        }
        else if (!player.CheckIfTouchingGround())
        {
            stateMachine.ChangeState(player.fallState);
        }
        
        if (attackPressed && player.CheckIfTouchingGround())
        {
            player.inputHandler.UseAttackInput();
            stateMachine.ChangeState(player.slashState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
