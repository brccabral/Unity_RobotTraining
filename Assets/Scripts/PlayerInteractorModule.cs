using System;
using UnityEngine;

public class PlayerInteractorModule : MonoBehaviour
{
    [SerializeField] private Transform interationRayOrigin;
    [SerializeField] private float interactionRange;
    [SerializeField] private LayerMask interactableLayers;

    public Action<GameObject> OnInteract;

    private GameObject selectedObject;
    private Interactible pickedUpObject;

    private void Update()
    {
        Ray ray = new Ray(interationRayOrigin.position, interationRayOrigin.forward);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, interactionRange, interactableLayers))
        {
            if (selectedObject != hitInfo.collider.gameObject)
            {
                selectedObject = hitInfo.collider.gameObject;
                OnInteract?.Invoke(selectedObject);
            }
        }
        else
        {
            if (selectedObject)
            {
                selectedObject = null;
                OnInteract?.Invoke(null);
            }
        }
    }

    public void InteractWith()
    {
        if (selectedObject)
        {
            Interactible interactible = selectedObject.GetComponent<Interactible>();
            interactible.OnStartInteraction.Invoke();

            if (interactible is InteractiblePickup)
            {
                OnInteract?.Invoke(null);
                pickedUpObject = interactible;
                pickedUpObject.transform.SetParent(interationRayOrigin);
            }
        }
    }

    public void StopInteractWith()
    {
        if (pickedUpObject)
        {
            pickedUpObject.transform.SetParent(null);
            pickedUpObject.OnStopInteraction.Invoke();
            pickedUpObject = null;
        }
    }
}
