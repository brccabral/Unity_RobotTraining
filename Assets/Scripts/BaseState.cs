using UnityEngine;

public abstract class BaseState
{
    public TurretController controller;

    public abstract void OnStateEnter();
    public abstract void OnStateRun();
    public abstract void OnStateExit();
}
