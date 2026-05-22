using UnityEngine;

public class IdleState : BaseState
{
    private Player player;

    public override void OnStateEnter()
    {
        player = GameManager.Instance.GetPlayer();
        Debug.Log("Play animation");
    }

    public override void OnStateRun()
    {
        if (Vector3.Distance(player.transform.position, controller.transform.position) < 4f)
        {
            controller.ChangeState(new AimingState());
        }

        Debug.Log("Check for target nearby");
    }

    public override void OnStateExit()
    {
        Debug.Log("OnStateExit");
    }
}
