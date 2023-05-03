using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerCombat : MonoBehaviour
{
    public bool IsAttacking { get; private set; } = false;
    public bool IsBlocking { get; private set; } = false;
    public bool IsCasting { get; private set; } = false;

    public void Attack(Animator animator)
    {
        StartCoroutine(Attacking(animator));
    }
    
    public void Cast()
    {
        StartCoroutine(Casting());
    }

    public void Block()
    {
        IsBlocking = true; 
    }

    public void UnBlock()
    {
        IsBlocking = false;
    }

    private IEnumerator Attacking(Animator animator)
    {
        IsAttacking = true;

        yield return new WaitForSeconds(0.01f);

        float animationTime = animator.GetCurrentAnimatorStateInfo(0).length;
        print(animationTime);

        yield return new WaitForSeconds(animationTime); 

        IsAttacking = false;
    }
    
    private IEnumerator Casting()
    {
        IsCasting = true;
        
        yield return new WaitForSeconds(1.94f); 

        IsCasting = false;
    }
}
