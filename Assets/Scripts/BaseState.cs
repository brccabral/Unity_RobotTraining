using UnityEngine;

public abstract class BaseState
{
    public TurretController controller;
    protected Transform target;
    protected float changeStateDistance;

    public abstract void OnStateEnter();
    public abstract void OnStateRun();
    public abstract void OnStateExit();
}
