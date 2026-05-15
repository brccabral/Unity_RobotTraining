using UnityEngine;

public class InteractiblePickup : Interactible
{
    [SerializeField] private Rigidbody rb;

    public void FreezeRb()
    {
        rb.isKinematic = true;
        rb.useGravity = false;
    }

    public void UnfreezeRb()
    {
        rb.isKinematic = false;
        rb.useGravity = true;
    }
}
