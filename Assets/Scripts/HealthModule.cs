using System;
using UnityEngine;

public class HealthModule : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;

    public Action OnHealthChanged;
    public Action OnDeath;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void IncreaseHealth(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void DecreaseHealth(int amount)
    {
        if (IsDead())
        {
            return;
        }

        currentHealth -= amount;
        if (IsDead())
        {
            currentHealth = 0;
            OnDeath?.Invoke();
        }
    }

    public bool IsDead()
    {
        return currentHealth <= 0;
    }
}
