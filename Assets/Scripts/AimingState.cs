using UnityEngine;

public class AimingState : BaseState
{
    private Vector3 offset;
    private LineRenderer line;

    public AimingState(Transform newTarget) => target = newTarget;

    public override void OnStateEnter()
    {
        offset = new Vector3(0, 0.3f, 0);
        line = controller.turretHead.GetComponentInChildren<LineRenderer>();
        line.enabled = true;
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
        line.enabled = false;
    }
}
