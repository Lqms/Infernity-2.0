using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    [SerializeField] private int _differentAttackAnimationsCount = 3;

    protected override void OnEnable()
    {
        /*
        _differentAttackAnimationsCount = 0;

        var states = GetComponentInParent<Animator>().runtimeAnimatorController.animationClips;

        foreach (var state in states)
        {
            print(state.name);

            if (state.name.StartsWith("Attack"))
                differentAttackAnimationsCount++;
        }

        print(differentAttackAnimationsCount);
        */

        PlayerController.PlayAnimation(AnimationName.ToString() + Random.Range(1, _differentAttackAnimationsCount + 1));
        PlayerController.Attack(PlayerController.HandleClick().point);
    }
}
