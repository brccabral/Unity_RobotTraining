using UnityEngine;

public class DoorControl : MonoBehaviour
{
    [SerializeField] private DoorTrigger doorTrigger;

    [SerializeField] private bool unlocked;
    [SerializeField] private Material lockedMaterial;
    [SerializeField] private Material unlockedMaterial;
    [SerializeField] private Renderer indicator;
    [SerializeField] private AudioClip doorUnlockSound;
    [SerializeField] private AudioClip doorLockSound;

    private AudioManager audioManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!audioManager)
        {
            audioManager = FindAnyObjectByType<AudioManager>();
        }

        if (unlocked)
        {
            Unlock();
        }
        else
        {
            Lock();
        }
    }

    public void Unlock()
    {
        unlocked = true;
        doorTrigger.gameObject.SetActive(true);
        indicator.material = unlockedMaterial;
        audioManager.PlayDoorLock(doorUnlockSound);
    }

    public void Lock()
    {
        if (unlocked)
        {
            audioManager.PlayDoorOpenClose(doorLockSound);
        }

        unlocked = false;
        doorTrigger.gameObject.SetActive(false);
        indicator.material = lockedMaterial;
    }

    public void DelayedLock(float delay)
    {
        Invoke(nameof(Lock), delay);
    }
}
