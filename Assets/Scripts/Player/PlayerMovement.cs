using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private KeyCode _movementKey = KeyCode.Mouse1;
    [SerializeField] private float _speed = 5;

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

                    _coroutine = StartCoroutine(Moving1(clickedPoint));
                }
            }
        }
    }

    private IEnumerator Moving2(Vector3 point)
    {
        float turnRate = 0.2f;

        transform.DOLookAt(point, turnRate);

        while (Vector3.Distance(point, transform.position) > 0.1f)
        {
            GetComponent<CharacterController>().SimpleMove(point);
            yield return null;
        }

        _coroutine = null;
    }


    private IEnumerator Moving1(Vector3 point)
    {
        GetComponent<Animator>().SetBool("IsRunning", true);
        float time = Vector3.Distance(point, transform.position) / _speed;
        float turnRate = 0.2f;

        yield return new WaitForSeconds(0.02f);

        transform.DOLookAt(point, turnRate);
        transform.DOMove(point, time);

        while (Vector3.Distance(point, transform.position) > 0.1f)
        {
            yield return null;
        }

        GetComponent<Animator>().SetBool("IsRunning", false);
        _coroutine = null;
    }

    private IEnumerator Moving(Vector3 point)
    {
        transform.DOLookAt(point, 0.2f);


        while (Vector3.Distance(point, transform.position) > 0.1f)
        {
            transform.Translate(new Vector3(0, 0, _speed * Time.deltaTime));
            yield return null; 
        }

        _coroutine = null;
    }
}
