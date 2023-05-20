using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private KeyCode _openPerkCardsKey = KeyCode.P;
    [SerializeField] private KeyCode _interactKey = KeyCode.E;
    
    public static KeyCode AttackKey = KeyCode.Mouse0;
    public static KeyCode MoveKey = KeyCode.Mouse1;
    public static KeyCode BlockKey = KeyCode.Space;
    public static KeyCode CastKey = KeyCode.LeftShift;
    
    public static event UnityAction OpenPerkCardsKeyPressed;
    public static event UnityAction InteractKeyPressed;

    private void Update()
    {
        CheckOpenCardsKeyDown();
        CheckInteractKeyDown();
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
            OpenPerkCardsKeyPressed?.Invoke();
        }
    }

    private void CheckInteractKeyDown()
    {
        if (Input.GetKeyDown(_interactKey))
        {
            InteractKeyPressed?.Invoke();
        }
    }
}
