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
            // terminal velocity
            if (upDownForce.y > -10)
            {
                upDownForce.y += gravityForce * Time.deltaTime;
            }
        }
    }

    public void AddForceUp(float force)
    {
        upDownForce.y = force;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, 0.075f);
    }
}
