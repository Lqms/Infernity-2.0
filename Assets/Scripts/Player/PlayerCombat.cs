using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerCombat : MonoBehaviour
{
    public bool IsAttacking { get; private set; } = false;
    public bool IsBlocking { get; private set; } = false;
    public bool IsCasting { get; private set; } = false;

    public void Attack()
    {
        StartCoroutine(Attacking());
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

    private IEnumerator Attacking()
    {
        IsAttacking = true;

        yield return new WaitForSeconds(1.94f); 

        IsAttacking = false;
    }

    private IEnumerator Casting()
    {
        IsCasting = true;
        
        yield return new WaitForSeconds(1.94f); 

        IsCasting = false;
    }
}
