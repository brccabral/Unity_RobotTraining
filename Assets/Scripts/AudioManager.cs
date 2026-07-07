using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private AudioSource doorLock;
    [SerializeField] private AudioSource doorOpenClose;
    [SerializeField] private AudioSource projectileSpawn;

    public void PlayDoorLock(AudioClip clip)
    {
        doorLock.PlayOneShot(clip);
    }

    public void PlayDoorOpenClose(AudioClip clip)
    {
        doorOpenClose.PlayOneShot(clip);
    }
    
    public void PlayProjectileSpawn(AudioClip clip)
    {
        projectileSpawn.PlayOneShot(clip);
    }
}
