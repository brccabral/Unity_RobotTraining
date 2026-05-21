using UnityEngine;

public class AimingState : BaseState
{
    private Vector3 offset;

    public override void OnStateEnter()
    {
        offset = new Vector3(0, 0.3f, 0);
        Debug.Log("Turn ON aiming effect");
    }

    public override void OnStateRun()
    {
        controller.turretHead.LookAt(controller.target.position + offset);
    }

    public override void OnStateExit()
    {
        Debug.Log("Turn OFF aiming effect");
    }
}
