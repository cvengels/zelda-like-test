﻿using UnityEngine;

public abstract class Entity : MonoBehaviour , IDamageable
{
    private int currentHP;
    public int initialHP = 3;

    protected virtual void Awake()
    {
        currentHP = initialHP;
    }
    public void TakeDamage()
    {
        currentHP--;
        Debug.Log($"{currentHP}/{initialHP}");
        if (currentHP <= 0)
        {
            Die();
        }
    }
    protected void RestoreHP()
    {
        currentHP = initialHP;
    }
    protected abstract void Die();
}