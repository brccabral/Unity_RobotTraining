using UnityEngine;

public class AimingState : BaseState
{
    private Vector3 offset;
    private LineRenderer line;
    private ShootingModule shootingModule;
    private float shootingRate = 1f;
    private float shootingTimer;

    public AimingState(Transform newTarget, float newChangeStateDistance)
    {
        target = newTarget;
        changeStateDistance = newChangeStateDistance;
    }

    public override void OnStateEnter()
    {
        offset = new Vector3(0, 0.3f, 0);
        line = controller.turretHead.GetComponentInChildren<LineRenderer>();
        line.enabled = true;
        shootingModule = controller.GetComponentInChildren<ShootingModule>();
    }

    public override void OnStateRun()
    {
        controller.turretHead.LookAt(target.position + offset);

        shootingTimer += Time.deltaTime;
        if (shootingTimer > shootingRate)
        {
            shootingTimer = 0;
            shootingModule.Shoot();
        }

        if (Vector3.Distance(target.position, controller.transform.position) > changeStateDistance)
        {
            controller.ChangeState(new IdleState(changeStateDistance));
        }
    }

    public override void OnStateExit()
    {
        line.enabled = false;
    }
}
