using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private KeyCode _openPerkCardsKey = KeyCode.P;
    
    public static KeyCode AttackKey = KeyCode.Mouse0;
    public static KeyCode MoveKey = KeyCode.Mouse1;
    public static KeyCode BlockKey = KeyCode.Space;

    public static KeyCode CastKey = KeyCode.LeftShift;
    
    public static event UnityAction OnOpenPerkCardsKeyPressed;

    private void Update()
    {
        CheckOpenCardsKeyDown();
    }

    public static bool CheckBlockKey()
    {
        if (Input.GetKey(BlockKey))
        {
            return true;
        }
        
        return false;
    }

    public static bool CheckAttackKeyDown()
    {
        if (Input.GetKeyDown(AttackKey))
        {
            return true;
        }
        
        return false;
    }
    
    public static bool CheckCastKeyDown()
    {
        if (Input.GetKeyDown(CastKey))
        {
            return true;
        }
        
        return false;
    }
    
    public static bool CheckMoveKeyDown()
    {
        if (Input.GetKeyDown(MoveKey))
        {
            return true;
        }

        return false;
    }

    private void CheckOpenCardsKeyDown()
    {
        if (Input.GetKeyDown(_openPerkCardsKey))
        {
            OnOpenPerkCardsKeyPressed?.Invoke();
        }
    }
}
