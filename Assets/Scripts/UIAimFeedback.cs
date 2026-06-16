using System;
using TMPro;
using UnityEngine;

public class UIAimFeedback : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI interactionText;
    [SerializeField] private PlayerInteractorModule playerInteractor;

    private void Start()
    {
        playerInteractor.OnInteract += DisplayInterationText;
    }

    private void DisplayInterationText(GameObject obj)
    {
        if (obj)
        {
            interactionText.text = "Press Right Button to interact with " + obj.name;
            interactionText.gameObject.SetActive(true);

            return;
        }

        HideInteractionText();
    }

    private void HideInteractionText()
    {
        interactionText.gameObject.SetActive(false);
    }
}
