using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    private Player player => (Player)entity;
    public PlayerIdleState(Player player, StateMachine stateMachine, string animNameBool) : base(player, stateMachine, animNameBool)
    {

    }

    public override void Enter()
    {
        base.Enter();
        player.SetVelocityX(0f);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(xInput != 0)
            stateMachine.ChangeState(player.moveState);           
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
