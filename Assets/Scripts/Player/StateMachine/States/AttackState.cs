using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    protected override void OnEnable()
    {
        PlayerController.PlayAnimation(AnimationName.ToString() + Random.Range(1, 3));
        PlayerController.Attack(PlayerController.HandleClick().point);
    }
}
