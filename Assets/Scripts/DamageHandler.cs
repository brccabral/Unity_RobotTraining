using System;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    [SerializeField] private int damage;

    private void OnTriggerEnter(Collider other)
    {
        HealthModule healthModule = other.GetComponent<HealthModule>();
        if (healthModule)
        {
            healthModule.DecreaseHealth(damage);
        }
    }
}
