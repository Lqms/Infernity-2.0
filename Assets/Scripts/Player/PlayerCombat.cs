using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerCombat : MonoBehaviour
{
    public bool IsAttacking { get; private set; } = false;

    public void Attack(Vector3 point)
    {
        StartCoroutine(Attacking(point));
    }

    private IEnumerator Attacking(Vector3 point)
    {
        IsAttacking = true;

        transform.DORotate(point, 0.2f); // не хочет поворачиваться в точку атаки, гад
        yield return new WaitForSeconds(0.01f);

        float animationTime = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length;
        print(animationTime);

        yield return new WaitForSeconds(animationTime); 

        IsAttacking = false;
    }
}
