using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public delegate void HealthEvent(Health target, float damage, GameObject attacker);
    public delegate void DieAction(Health target, GameObject attacker);

    [SerializeField]
    private float _totalHP = 100f;
    [SerializeField]
    private float _HP;

    public enum Team
    {
        playerTeam,
        enemyTeam
    }
    public Team team;

    public virtual float TotalHP
    {
        get 
        {
            return _totalHP;
        }
        set 
        {
            _totalHP = value;
        }
    }
    public virtual float HP
    {
        get 
        {
            return _HP;
        }
        set 
        {
            _HP = Mathf.Clamp(value, 0, _totalHP);
        }
    }

    public static event HealthEvent OnDamaged;
    public event DieAction OnDie;

    private void Awake()

    {
        InitHP();
    }
    public virtual void OnEnable()
    {
        
    }
    
    public virtual void InitHP()
    {
        _HP = _totalHP;
    }

    public virtual void OnDisable()
    {
        
    }

    public virtual void DealDamage(float damage, GameObject attacker)
    {
        HP -= damage;
        OnDamaged?.Invoke(this, damage, attacker);
        if (HP <= 0)
        {
            OnDie?.Invoke(this, attacker);
        }
    }
}
