using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static KeyCode AttackKey = KeyCode.Mouse0;
    public static KeyCode MoveKey = KeyCode.Mouse1;
    public static KeyCode BlockKey = KeyCode.Space;
    
    public static bool CheckBlockKeyDown()
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
    
    public static bool CheckMoveKeyDown()
    {
        if (Input.GetKeyDown(MoveKey))
        {
            return true;
        }

        return false;
    }
}
