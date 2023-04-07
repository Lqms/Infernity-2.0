using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    protected override void OnEnable()
    {
        base.OnEnable();

        PlayerController.Attack(PlayerController.HandleClick().point);
    }
}
