using UnityEngine;

public class AimingState : BaseState
{
    private Vector3 offset;

    public AimingState(Transform newTarget) => target = newTarget;

    public override void OnStateEnter()
    {
        offset = new Vector3(0, 0.3f, 0);
        Debug.Log("Turn ON aiming effect");
    }

    public override void OnStateRun()
    {
        controller.turretHead.LookAt(target.position + offset);

        if (Vector3.Distance(target.position, controller.transform.position) > 4f)
        {
            controller.ChangeState(new IdleState());
        }
    }

    public override void OnStateExit()
    {
        Debug.Log("Turn OFF aiming effect");
    }
}
