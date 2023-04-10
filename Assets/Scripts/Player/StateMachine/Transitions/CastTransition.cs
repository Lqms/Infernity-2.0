using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastTransition : Transition
{
    private void Update()
    {
        if (PlayerInput.CheckCastKeyDown() && !PlayerController.IsCasting)
            NeedTransit = true;
    }
}
