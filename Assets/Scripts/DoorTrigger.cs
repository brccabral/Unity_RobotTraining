using System;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    private static readonly int IsOpen = Animator.StringToHash("IsOpen");
    [SerializeField] private Animator doorAnimator;

    [SerializeField] private AudioClip doorOpenSound;
    [SerializeField] private AudioClip doorCloseSound;
    private AudioManager audioManager;

    private void Start()
    {
        if (!audioManager)
        {
            audioManager = FindAnyObjectByType<AudioManager>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        doorAnimator.SetBool(IsOpen, true);
        audioManager.PlayDoorOpenClose(doorOpenSound);
    }

    private void OnTriggerExit(Collider other)
    {
        doorAnimator.SetBool(IsOpen, false);
        audioManager.PlayDoorOpenClose(doorCloseSound);
    }
}
