using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public ProjectilePooling poolParent;

    [SerializeField] private float speed = 10f;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StartBullet()
    {
        Invoke(nameof(ResetBullet), 5f);
        rb.linearVelocity = transform.forward * speed;
    }

    void ResetBullet()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        CancelInvoke(); // in case ResetBullet is called somewhere else
        poolParent.ArchiveProjectile(this);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            return;
        }

        ResetBullet();
    }
}
