using System;
using UnityEngine;

public class HealthModule : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;

    public Action<int> OnHealthChanged;
    public Action OnDeath;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Start()
    {
        OnHealthChanged?.Invoke(currentHealth);
    }

    public void IncreaseHealth(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        OnHealthChanged?.Invoke(currentHealth);
    }

    public void DecreaseHealth(int amount)
    {
        if (IsDead())
        {
            return;
        }

        currentHealth -= amount;
        OnHealthChanged?.Invoke(currentHealth);
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
