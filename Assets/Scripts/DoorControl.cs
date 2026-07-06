using UnityEngine;

public class DoorControl : MonoBehaviour
{
    [SerializeField] private DoorTrigger doorTrigger;

    [SerializeField] private bool unlocked;
    [SerializeField] private Material lockedMaterial;
    [SerializeField] private Material unlockedMaterial;
    [SerializeField] private Renderer indicator;

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
        indicator.material = unlockedMaterial;
    }

    public void Lock()
    {
        unlocked = false;
        doorTrigger.gameObject.SetActive(false);
        indicator.material = lockedMaterial;
    }

    public void DelayedLock(float delay)
    {
        Invoke(nameof(Lock), delay);
    }
}
