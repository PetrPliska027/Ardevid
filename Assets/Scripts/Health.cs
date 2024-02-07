using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float maxHealth = 100f;
    private float currentHealth;

    public bool isPlayer;

    public float CurrentHealth
    {
        get { return currentHealth; }
        set { currentHealth = value; }
    }

    public delegate void HPUpdated(Health target);
    public static event HPUpdated OnHPUpdated;

    private void Awake()
    {
        InitHP();
    }

    private void InitHP()
    {
        CurrentHealth = maxHealth;
    }

    public void Health_HPUpdated()
    {
        OnHPUpdated?.Invoke(this);
    }
}
