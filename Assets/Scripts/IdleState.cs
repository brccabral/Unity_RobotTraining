using UnityEngine;

public class IdleState : BaseState
{
    public override void OnStateEnter()
    {
        target = GameManager.Instance.GetPlayer().transform;
    }

    public override void OnStateRun()
    {
        if (Vector3.Distance(target.position, controller.transform.position) < 4f)
        {
            controller.ChangeState(new AimingState(target));
        }
    }

    public override void OnStateExit()
    {
    }
}
