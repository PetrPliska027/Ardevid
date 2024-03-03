using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : Health
{
    public delegate void HPUpdated(HealthPlayer target);

    public static event HPUpdated OnHPUpdated;
    public static event HPUpdated OnTotalHPUpdated;
    public new static event HPUpdated OnDamaged;
    public static event HPUpdated OnHealed;
    public static event HPUpdated OnPlayerDied;

    public override float TotalHP 
    {
        get => base.TotalHP;
        set
        {
            base.TotalHP = value;
            OnTotalHPUpdated?.Invoke(this);
        }
    }
    public override float HP
    {
        get => base.HP;
        set 
        {
            base.HP = value;
            OnHPUpdated?.Invoke(this);
        }
    }

    public override void OnEnable()
    {
        base.OnEnable();
        base.OnDie += HealthPlayer_OnDie;
    }

    public override void InitHP()
    {
        base.InitHP();
    }

    public override void OnDisable()
    {
        base.OnDisable();
        base.OnDie -= HealthPlayer_OnDie;
    }

    public override void DealDamage(float damage, GameObject attacker)
    {
        OnDamaged?.Invoke(this);
        base.DealDamage(damage, attacker);
    }

    private void HealthPlayer_OnDie(Health target, GameObject attacker)
    {
        HealthPlayer.OnPlayerDied?.Invoke(this);
    }
}
