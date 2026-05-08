using UnityEngine;

public class ShootingModule : MonoBehaviour
{
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private Transform weaponTip;

    public void Shoot()
    {
        Instantiate(projectilePrefab, weaponTip.position, weaponTip.rotation);
    }
}
