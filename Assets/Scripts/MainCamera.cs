using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Vector3 _baseRotation;
    [SerializeField] private Vector3 _baseOffset;

    private bool _canFollow = true;

    public bool CanFollow
    {
        get { return _canFollow; }
        set { _canFollow = value; }
    }

    private void Start()
    {
        StartCoroutine(Following(_player));
    }

    private IEnumerator Following(Transform target)
    {
        while (_canFollow)
        {
            transform.position = new Vector3(target.position.x, _baseOffset.y, target.position.z + _baseOffset.z);
            yield return null;
        }
    }

    private void IsVisible()
    {
        Vector3 Ray_start_position = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Ray ray = Camera.main.ScreenPointToRay(Ray_start_position);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        var obj = hit.collider.gameObject;

        if (obj.TryGetComponent(out MeshRenderer meshRenderer))
        {
            meshRenderer.enabled = false;
        }

        print(obj.name);
    }

    private void FixedUpdate()
    {
        // IsVisible();
    }
}
