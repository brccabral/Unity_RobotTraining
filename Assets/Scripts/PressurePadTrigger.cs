using System;
using UnityEngine;
using UnityEngine.Events;

public class PressurePadTrigger : MonoBehaviour
{
    public UnityEvent OnPressureActivate;
    public UnityEvent OnPressureDeactivate;

    public void OnTriggerEnter(Collider other)
    {
        OnPressureActivate.Invoke();
    }

    public void OnTriggerExit(Collider other)
    {
        OnPressureDeactivate.Invoke();
    }
}
