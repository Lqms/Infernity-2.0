using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastState : State
{
    protected override void OnEnable()
    {
        base.OnEnable();
        
        PlayerController.Cast(PlayerController.HandleClick().point);
    }
}
