using System;
using UnityEngine;

public class CustomPhysicsModule : MonoBehaviour
{
    [SerializeField] private float gravityForce = -9.8f;
    [SerializeField] private LayerMask walkableLayers;
    public Vector3 upDownForce;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.CheckSphere(transform.position, 0.075f, walkableLayers))
        {
            upDownForce.y = 0;
        }
        else
        {
            upDownForce.y = gravityForce;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, 0.075f);
    }
}
