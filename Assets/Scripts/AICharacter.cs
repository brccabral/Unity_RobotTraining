using System;
using UnityEngine;
using UnityEngine.AI;

public class AICharacter : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform goal;

    private void Start()
    {
        InvokeRepeating(nameof(UpdateDestination), 0.2f, 1f);
    }

    private void UpdateDestination()
    {
        agent.SetDestination(goal.position);
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, goal.position) < 1)
        {
            // TODO: interact with the player 
        }
    }
}
