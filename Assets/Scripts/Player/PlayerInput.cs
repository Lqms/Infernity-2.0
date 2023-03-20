using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private KeyCode _attackKey = KeyCode.Mouse0;
    [SerializeField] private KeyCode _moveKey = KeyCode.Mouse1;

    public static event UnityAction AttackKeyPressed;
    public static event UnityAction MoveKeyPressed;

    private void Update()
    {
        if (Input.GetKeyDown(_attackKey))
            AttackKeyPressed?.Invoke();

        if (Input.GetKeyDown(_moveKey))
            MoveKeyPressed?.Invoke();
    }
}
