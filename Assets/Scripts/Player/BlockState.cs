using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockState : State
{
    public void Block(KeyCode key)
    {
        if (ActiveCoroutine != null)
            StopCoroutine(ActiveCoroutine);

        ActiveCoroutine = StartCoroutine(Blocking(key));
    }

    private IEnumerator Blocking(KeyCode key)
    {
        while (Input.GetKeyUp(key) == false)
        {
            yield return null;
        }

        Complete();
    }
}
