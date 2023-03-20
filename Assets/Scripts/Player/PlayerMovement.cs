using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;

    private Coroutine _coroutine;

    public void TryMove(Vector3 point, float speed)
    {
        if (_agent.CalculatePath(point, new NavMeshPath()) == false)
        {
            print("can't move here");
            return;
        }

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _agent.speed = speed;
        _coroutine = StartCoroutine(Moving(point));
    }


    private IEnumerator Moving(Vector3 point)
    {
        _agent.SetDestination(point);
        GetComponent<Animator>().SetBool("IsRunning", true);

        while (Vector3.Distance(transform.position, point) > _agent.radius)
            yield return null;

        GetComponent<Animator>().SetBool("IsRunning", false);
    }
}
