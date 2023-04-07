using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTransition : Transition
{
    private void Update()
    {
        if (PlayerInput.CheckAttackKeyDown() && !PlayerController.IsAttacking)
            NeedTransit = true;
    }
}
