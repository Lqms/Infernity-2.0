using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockTransition : Transition
{
    private void Update()
    {
        if (PlayerInput.CheckBlockKeyDown() && !PlayerController.IsBlocking)
            NeedTransit = true;
    }
}