using System;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    private static readonly int IsOpen = Animator.StringToHash("IsOpen");
    [SerializeField] private Animator doorAnimator;

    [SerializeField] private AudioClip doorOpenSound;
    [SerializeField] private AudioClip doorCloseSound;
    private AudioManager audioManager;

    private void Awake()
    {
        if (!audioManager)
        {
            audioManager = FindAnyObjectByType<AudioManager>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ForceOpen();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            doorAnimator.SetBool(IsOpen, false);
            audioManager.PlayDoorOpenClose(doorCloseSound);
        }
    }

    public void ForceOpen()
    {
        doorAnimator.SetBool(IsOpen, true);
        audioManager.PlayDoorOpenClose(doorOpenSound);
    }
}
