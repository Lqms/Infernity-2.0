using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private GameObject _cardCanvas;
    [SerializeField] private GameObject _cardAnimationObject;
    [SerializeField] private MainCamera _camera;
    private void OnEnable()
    {
        StartCoroutine(StartCardAnimation());
    }

    IEnumerator StartCardAnimation()
    {
        yield return new WaitForSeconds(1.5f);
        _camera.CanFollow = false;
        _camera.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        _camera.transform.position = new Vector3(0f, 1f, _cardAnimationObject.transform.position.z - 15f);
        yield return new WaitForSeconds(0.5f);
        _cardCanvas.SetActive(true);
    }
}
