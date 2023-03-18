using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Vector3 _baseRotation;
    [SerializeField] private Vector3 _baseOffset;

    private void Start()
    {
        StartCoroutine(Following(_player));
    }


    private IEnumerator Following(Transform target)
    {
        while (true)
        {
            transform.position = new Vector3(target.position.x, _baseOffset.y, target.position.z + _baseOffset.z);
            yield return null;
        }
    }
}
