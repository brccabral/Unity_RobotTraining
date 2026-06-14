using UnityEngine;

public class HealthModule : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;
    
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
        currentHealth -= amount;
    }

    public bool IsDead()
    {
        return currentHealth <= 0;
    }
}
