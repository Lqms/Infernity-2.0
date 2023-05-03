using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CardAnimation : MonoBehaviour
{
    [SerializeField] private Transform[] _routes;
    [SerializeField] private float _speedModifier = 1;
    [SerializeField] private ParticleSystem _endExplosionVFX;
    [SerializeField] private GameObject _camera;

    private void Start()
    {
        StartAnimation();
    }

    public void StartAnimation()
    {
        StartCoroutine(Animating());
    }

    private IEnumerator Animating()
    {
        float animationTime = _routes.Length / _speedModifier;
        transform.DORotate(new Vector3(0, 180, 0), _routes.Length / _speedModifier);
        transform.DOScale(transform.localScale * 3, animationTime);
        _camera.transform.DOMoveZ(-23, animationTime * 1.7f);

        foreach (var route in _routes)
        {
            float tParam = 0;

            Vector3 firstPoint = route.GetChild(0).position;
            Vector3 secondPoint = route.GetChild(1).position;
            Vector3 thirdPoint = route.GetChild(2).position;
            Vector3 fourthPoint = route.GetChild(3).position;

            while (tParam < 1)
            {
                tParam += Time.deltaTime * _speedModifier;

                transform.position = Mathf.Pow(1 - tParam, 3) * firstPoint +
                                     3 * Mathf.Pow(1 - tParam, 2) * tParam * secondPoint +
                                     3 * (1 - tParam) * Mathf.Pow(tParam, 2) * thirdPoint +
                                     Mathf.Pow(tParam, 3) * fourthPoint;
                
                yield return null;
            }

            tParam = 0;
            yield return null;
        }

        transform.DOShakePosition(1, new Vector3(1, 1, 0));
        _endExplosionVFX.Play();
        yield return new WaitForSeconds(1.5f);
        //transform.DOMove(_camera.transform.position + new Vector3(-0.5f, 1f, -2f), 1f);
    }
}
