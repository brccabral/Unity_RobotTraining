using UnityEngine;

public class TurretController : MonoBehaviour
{
    public Transform turretHead;
    public Transform target;

    private BaseState currentState;

    private void Start()
    {
        ChangeState(new IdleState());
    }

    private void Update()
    {
        currentState?.OnStateRun();
    }

    public void ChangeState(BaseState newState)
    {
        currentState?.OnStateExit();
        currentState = newState;
        currentState.controller = this;
        currentState.OnStateEnter();
    }
}
