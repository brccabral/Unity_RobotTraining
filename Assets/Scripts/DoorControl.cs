using UnityEngine;

public class DoorControl : MonoBehaviour
{
    [SerializeField] private DoorTrigger doorTrigger;
    [SerializeField] private MeshRenderer doorMesh;

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
        Debug.Log("Unlocking door");
        unlocked = true;
        doorMesh.material.color = Color.blue;
        doorTrigger.gameObject.SetActive(true);
    }

    public void Lock()
    {
        unlocked = false;
        doorMesh.material.color = Color.red;
        doorTrigger.gameObject.SetActive(false);
    }
}
