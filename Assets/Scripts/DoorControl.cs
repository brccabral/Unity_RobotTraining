using UnityEngine;

public class DoorControl : MonoBehaviour
{
    [SerializeField] private DoorTrigger doorTrigger;

    [SerializeField] private bool unlocked;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
    }

    public void Lock()
    {
        unlocked = false;
        doorTrigger.gameObject.SetActive(false);
    }

    public void DelayedLock(float delay)
    {
        Invoke(nameof(Lock), delay);
    }
}
