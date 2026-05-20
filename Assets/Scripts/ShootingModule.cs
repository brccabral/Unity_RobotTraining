using UnityEngine;

public class ShootingModule : MonoBehaviour
{
    [SerializeField] private ProjectilePooling projectilePool;
    [SerializeField] private Transform weaponTip;

    public void Shoot()
    {
        var projectile = projectilePool.RetrieveProjectile();
        projectile.transform.position = weaponTip.position;
        projectile.transform.rotation = weaponTip.rotation;
        projectile.gameObject.SetActive(true);
        projectile.StartBullet();
    }
}
