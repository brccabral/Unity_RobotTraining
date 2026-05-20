using System;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePooling : MonoBehaviour
{
    [SerializeField] private int poolAmount;
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private List<Projectile> availableProjectiles;
    [SerializeField] private List<Projectile> usedProjectiles;

    private void Awake()
    {
        while (availableProjectiles.Count < poolAmount)
        {
            var projectile = Instantiate(projectilePrefab, transform, true);
            projectile.gameObject.SetActive(false);
            projectile.poolParent = this;

            availableProjectiles.Add(projectile);
        }
    }

    public Projectile RetrieveProjectile()
    {
        if (availableProjectiles.Count == 0)
        {
            return null;
        }

        var projectile = availableProjectiles[0];
        availableProjectiles.RemoveAt(0);
        usedProjectiles.Add(projectile);

        return projectile;
    }

    public void ArchiveProjectile(Projectile projectile)
    {
        if (!usedProjectiles.Contains(projectile))
        {
            return;
        }

        projectile.gameObject.SetActive(false);
        usedProjectiles.Remove(projectile);
        availableProjectiles.Add(projectile);
    }
}
