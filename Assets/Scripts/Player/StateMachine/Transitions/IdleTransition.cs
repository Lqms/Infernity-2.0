using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleTransition : Transition
{
    private void Update()
    {
        if (PlayerController.IsMovementStopped && !PlayerController.IsAttacking)
            NeedTransit = true;
    }
}
