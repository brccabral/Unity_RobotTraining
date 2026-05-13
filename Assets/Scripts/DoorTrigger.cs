using System;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    private static readonly int IsOpen = Animator.StringToHash("IsOpen");
    [SerializeField] private Animator doorAnimator;

    private void OnTriggerEnter(Collider other)
    {
        doorAnimator.SetBool(IsOpen, true);
    }

    private void OnTriggerExit(Collider other)
    {
        doorAnimator.SetBool(IsOpen, false);
    }
}
