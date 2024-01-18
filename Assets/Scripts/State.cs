using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    protected StateMachine stateMachine;
    protected Entity entity;

    protected float startTime;

    protected string animBoolName;

    public State(Entity entity, StateMachine stateMachine, string animBoolName)
    {
        this.entity = entity;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        entity.anim.SetBool(animBoolName, true);
        entity.anim.SetTrigger(animBoolName);
        startTime = Time.time;
    }

    public virtual void Exit()
    {
        entity.anim.SetBool(animBoolName, false);
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {

    }
}
