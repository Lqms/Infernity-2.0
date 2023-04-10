using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockState : State
{
    protected override void OnEnable()
    {
        base.OnEnable();
        
        PlayerController.Block();
    }

    private void Update()
    {
        if (!PlayerInput.CheckBlockKeyDown())
            PlayerController.UnBlock();
    }
}