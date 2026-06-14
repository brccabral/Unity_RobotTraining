using System;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float damageRate;
    private HealthModule healthModule;

    private void OnTriggerEnter(Collider other)
    {
        healthModule = other.GetComponent<HealthModule>();
        if (!healthModule)
        {
            return;
        }

        if (damageRate > 0)
        {
            InvokeRepeating(nameof(DealDamage), 0, damageRate);
        }
        else
        {
            DealDamage();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        healthModule = null;
        CancelInvoke();
    }

    private void DealDamage()
    {
        if (healthModule)
        {
            healthModule.DecreaseHealth(damage);
        }
    }
}
