using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;

    private Coroutine _coroutine;

    private bool _canMove = true;
    
    public bool IsMovementStopped => _agent.isStopped;

    public bool CanMove => _canMove;
    
    public void Move(Vector3 point)
    {
        if (_canMove)
        {
            _agent.isStopped = false;
            _agent.SetDestination(point);
        
            if (_coroutine != null)
                StopCoroutine(_coroutine);
        
            _coroutine = StartCoroutine(Moving(point));
        }
    }

    public void StopMovement()
    {
        _agent.isStopped = true;
    }

    private IEnumerator Moving(Vector3 destination)
    {
        while (Vector3.Distance(_agent.transform.position, destination) > _agent.radius)
        {
            yield return null;
        }
        
        StopMovement();
        _coroutine = null;
    }
}
