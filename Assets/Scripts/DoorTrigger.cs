using System;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private GameObject door;

    private void OnTriggerEnter(Collider other)
    {
        door.SetActive(false);
    }
}
