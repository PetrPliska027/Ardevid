using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : State
{
    protected int xInput;

    private Player player => (Player)entity;
    public PlayerFallState(Player player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
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

        player.CheckIfShouldFlip(xInput);

        player.SetVelocityX(player.moveVelocity * xInput);

        if (player.CheckIfTouchingGround())
        {
            player.inputHandler.UseJumpInput();
            stateMachine.ChangeState(player.idleState);
        }

        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
