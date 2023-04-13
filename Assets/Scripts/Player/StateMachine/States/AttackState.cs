using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    protected override void OnEnable()
    {
        int differentAttackAnimationsCount = 3;

        PlayerController.PlayAnimation(AnimationName.ToString() + Random.Range(1, differentAttackAnimationsCount + 1));
        PlayerController.Attack(PlayerController.HandleClick().point);
    }
}
