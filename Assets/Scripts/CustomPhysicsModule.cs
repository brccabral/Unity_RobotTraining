using System;
using UnityEngine;

public class CustomPhysicsModule : MonoBehaviour
{
    [SerializeField] private float gravityForce = -9.8f;
    [SerializeField] private LayerMask walkableLayers;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.CheckSphere(transform.position, 0.075f, walkableLayers))
        {
            Debug.Log("Colliding with floor");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, 0.075f);
    }
}
