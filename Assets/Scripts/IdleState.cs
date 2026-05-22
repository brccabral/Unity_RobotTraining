using UnityEngine;

public class IdleState : BaseState
{
    public override void OnStateEnter()
    {
        target = GameManager.Instance.GetPlayer().transform;
        Debug.Log("Play animation");
    }

    public override void OnStateRun()
    {
        if (Vector3.Distance(target.position, controller.transform.position) < 4f)
        {
            controller.ChangeState(new AimingState(target));
        }

        Debug.Log("Check for target nearby");
    }

    public override void OnStateExit()
    {
        Debug.Log("OnStateExit");
    }
}
