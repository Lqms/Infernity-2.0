using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public bool IsAttacking { get; private set; } = false;

    public void Attack()
    {
        StartCoroutine(Attacking());
    }

    private IEnumerator Attacking()
    {
        IsAttacking = true;

        yield return new WaitForSeconds(1.94f); 

        IsAttacking = false;
    }
}
