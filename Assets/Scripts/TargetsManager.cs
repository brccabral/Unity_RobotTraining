using System;
using UnityEngine;
using UnityEngine.Events;

public class TargetsManager : MonoBehaviour
{
    [SerializeField] private int countTargets;
    [SerializeField] private UnityEvent OnTargetsDestroyed;

    public void TargetDestroyed()
    {
        countTargets--;
        if (countTargets == 0)
        {
            OnTargetsDestroyed.Invoke();
        }
    }
}
