using System;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private Vector3 direction;
    [SerializeField] private Collider moveBoundaries;

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
}
