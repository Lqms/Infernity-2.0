using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.AI;

public class MovementState : State
{
    [SerializeField] private NavMeshAgent _agent;

    public void MoveToPoint(Vector3 point)
    {
        if (ActiveCoroutine != null)
            StopCoroutine(ActiveCoroutine);

        _agent.isStopped = false;
        _agent.speed = PlayerStats.MovementSpeed * Constants.PlayerMovementSpeedCoeff;
        ActiveCoroutine = StartCoroutine(MovingToPoint(point));
    }

    private IEnumerator MovingToPoint(Vector3 point)
    {
        _agent.SetDestination(point);

        while (Vector3.Distance(transform.position, point) > _agent.radius)
            yield return null;

        _agent.isStopped = true;
        Complete();
    }

    private void OnDisable()
    {
        _agent.isStopped = true;
    }
}
