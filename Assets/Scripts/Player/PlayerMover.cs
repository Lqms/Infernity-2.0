using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;

    public bool IsMovementStopped => _agent.isStopped;
    
    public void Move(Vector3 point)
    {
        _agent.isStopped = false;
        _agent.SetDestination(point);
    }

    public void StopMovement()
    {
        _agent.isStopped = true;
    }
}
