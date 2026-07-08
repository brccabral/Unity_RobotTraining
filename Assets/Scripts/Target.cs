using System;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private Vector3 direction;
    [SerializeField] private Collider moveBoundaries;
    [SerializeField] private TargetsManager targetsManager;

    private void Update()
    {
        transform.Translate(direction * Time.deltaTime);
    }

    private void ChangeDirection()
    {
        direction = -direction;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == moveBoundaries)
        {
            ChangeDirection();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            targetsManager.TargetDestroyed();
            Destroy(gameObject);
        }
    }
}
