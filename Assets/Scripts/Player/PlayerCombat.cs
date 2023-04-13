using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerCombat : MonoBehaviour
{
    public bool IsAttacking { get; private set; } = false;

    public void Attack(Vector3 point, Animator animator)
    {
        StartCoroutine(Attacking(point, animator));
    }

    private IEnumerator Attacking(Vector3 point, Animator animator)
    {
        IsAttacking = true;

        transform.DORotate(point, 0.2f); // не хочет поворачиваться в точку атаки, гад
        yield return new WaitForSeconds(0.01f);

        float animationTime = animator.GetCurrentAnimatorStateInfo(0).length;
        print(animationTime);

        yield return new WaitForSeconds(animationTime); 

        IsAttacking = false;
    }
}
