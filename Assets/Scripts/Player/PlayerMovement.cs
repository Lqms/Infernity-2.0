using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private KeyCode _movementKey = KeyCode.Mouse1;
    [SerializeField] private float _speed = 5;
    [SerializeField] private NavMeshAgent _agent;

    private Coroutine _coroutine;

    private void Update()
    {
        if (Input.GetKeyDown(_movementKey))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit clickedPointInfo))
            {
                if (clickedPointInfo.collider.TryGetComponent(out MeshCollider meshCollider))
                {
                    Vector3 clickedPoint = new Vector3(clickedPointInfo.point.x, transform.position.y, clickedPointInfo.point.z);

                    if (_coroutine != null)
                        StopCoroutine(_coroutine);

                    _coroutine = StartCoroutine(Moving(clickedPoint));
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GetComponent<Animator>().SetTrigger("Attack");
            _agent.isStopped = true;
        }
    }

    private IEnumerator Attacking()
    {
        yield return null;
    }


    private IEnumerator Moving(Vector3 point)
    {
        _agent.isStopped = false;
        _agent.SetDestination(point);
        GetComponent<Animator>().SetBool("IsRunning", true);

        while (Vector3.Distance(transform.position, point) > _agent.radius)
            yield return null;

        GetComponent<Animator>().SetBool("IsRunning", false);
    }
}
