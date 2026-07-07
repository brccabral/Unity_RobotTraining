using UnityEngine;

public class ShootingModule : MonoBehaviour
{
    [SerializeField] private ProjectilePooling projectilePool;
    [SerializeField] private Transform weaponTip;

    [SerializeField] private AudioClip projectileSpawnSound;
    private AudioManager audioManager;

    private void Start()
    {
        if (!audioManager)
        {
            audioManager = FindAnyObjectByType<AudioManager>();
        }
    }

    public void Shoot()
    {
        var projectile = projectilePool.RetrieveProjectile();
        projectile.transform.position = weaponTip.position;
        projectile.transform.rotation = weaponTip.rotation;
        projectile.gameObject.SetActive(true);
        projectile.StartBullet();

        audioManager.PlayProjectileSpawn(projectileSpawnSound);
    }
}
