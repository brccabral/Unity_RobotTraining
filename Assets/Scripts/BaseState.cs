using UnityEngine;

public abstract class BaseState
{
    public TurretController controller;
    protected Transform target;

    public abstract void OnStateEnter();
    public abstract void OnStateRun();
    public abstract void OnStateExit();
}
