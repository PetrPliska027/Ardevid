using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    private Player player => (Player)entity;
    public PlayerMoveState(Player player, StateMachine stateMachine, string animNameBool) : base(player, stateMachine, animNameBool)
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

        player.CheckIfShouldFlip(xInput);

        player.SetVelocityX(player.moveVelocity * xInput);

        if(xInput == 0)
            stateMachine.ChangeState(player.idleState);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
