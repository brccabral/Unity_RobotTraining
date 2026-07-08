using UnityEngine;

public class IdleState : BaseState
{
    public IdleState(float newChangeStateDistance) => changeStateDistance = newChangeStateDistance;

    private float lookAtRadius = 5f;
    private float lookAtSpeed = 1f;
    private float lookAtChangeRate = 3f;

    private Quaternion targetRotation;
    private float lookAtTimer;


    public override void OnStateEnter()
    {
        target = GameManager.Instance.GetPlayer().transform;
        PickNewTarget();
    }

    private void PickNewTarget()
    {
        var direction = Random.onUnitSphere;
        var targetPoint = controller.transform.position + direction * lookAtRadius;
        targetRotation = Quaternion.LookRotation(targetPoint - controller.transform.position, Vector3.up);
    }

    public override void OnStateRun()
    {
        controller.turretHead.transform.rotation = Quaternion.Slerp(controller.turretHead.transform.rotation,
            targetRotation, Time.deltaTime * lookAtSpeed);
        lookAtTimer += Time.deltaTime;
        if (lookAtTimer > lookAtChangeRate)
        {
            lookAtTimer = 0;
            PickNewTarget();
        }

        if (Vector3.Distance(target.position, controller.transform.position) < changeStateDistance)
        {
            controller.ChangeState(new AimingState(target, changeStateDistance));
        }
    }

    public override void OnStateExit()
    {
    }
}
