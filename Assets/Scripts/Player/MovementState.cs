using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.AI;

public class MovementState : State
{
    [SerializeField] private NavMeshAgent _agent;

    public void TryMoveToPoint(Vector3 point)
    {
        float distance = Vector3.Distance(new Vector3(point.x, 0, point.z), new Vector3(transform.position.x, 0, transform.position.z));

        if (distance < 1)
        {
            transform.DOLookAt(point, Constants.PlayerTurnRateCoeff / (PlayerStats.MovementSpeed * Constants.PlayerMovementSpeedCoeff));
            Complete();
            return;
        }

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
