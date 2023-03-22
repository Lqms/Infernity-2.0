using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastSpellState : State
{
    public void Cast()
    {
        if (ActiveCoroutine != null)
            return;

        ActiveCoroutine = StartCoroutine(Casting());
    }

    private IEnumerator Casting()
    {
        yield return new WaitForSeconds(BaseAnimationTime);
        print("Casted!");
        Complete();
    }
}
