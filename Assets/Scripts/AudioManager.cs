using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private AudioSource doorLock;
    [SerializeField] private AudioSource doorOpenClose;

    public void PlayDoorLock(AudioClip clip)
    {
        doorLock.PlayOneShot(clip);
    }

    public void PlayDoorOpenClose(AudioClip clip)
    {
        doorOpenClose.PlayOneShot(clip);
    }
}
