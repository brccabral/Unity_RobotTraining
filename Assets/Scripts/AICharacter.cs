using System;
using UnityEngine;
using UnityEngine.AI;

public class AICharacter : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform goal;

    private void Start()
    {
        agent.SetDestination(goal.position);
    }
}
