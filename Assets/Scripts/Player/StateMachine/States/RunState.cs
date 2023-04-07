using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : State
{
    protected override void OnEnable()
    {
        base.OnEnable();
        
        PlayerController.Move(PlayerController.HandleClick().point);
    }
}
