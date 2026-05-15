using UnityEngine;

public class PlayerInteractorModule : MonoBehaviour
{
    [SerializeField] private Transform interationRayOrigin;
    [SerializeField] private float interactionRange;
    [SerializeField] private LayerMask interactableLayers;

    private GameObject selectedObject;

    private void Update()
    {
        Ray ray = new Ray(interationRayOrigin.position, interationRayOrigin.forward);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, interactionRange, interactableLayers))
        {
            Debug.Log("Press left button to interact with: " + hitInfo.collider.gameObject.name);
            selectedObject = hitInfo.collider.gameObject;
        }
        else
        {
            selectedObject = null;
        }
    }

    public void InteractWith()
    {
        if (selectedObject)
        {
            Interactible interactible = selectedObject.GetComponent<Interactible>();
            interactible.OnStartInteraction.Invoke();
        }
    }
}
