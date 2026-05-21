using UnityEngine;

public class IdleState : BaseState
{
    public override void OnStateEnter()
    {
        Debug.Log("Play animation");
    }

    public override void OnStateRun()
    {
        Debug.Log("Check for target nearby");
    }

    public override void OnStateExit()
    {
        Debug.Log("OnStateExit");
    }
}
