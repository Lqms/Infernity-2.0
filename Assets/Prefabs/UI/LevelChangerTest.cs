using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelChangerTest : MonoBehaviour
{
    private int _floor = 0;

    public static event UnityAction<int> PlayerEnteredNewFloor;

    private void Start()
    {
        PlayerEnteredNewFloor?.Invoke(_floor);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            _floor++;
            print(_floor);
            PlayerEnteredNewFloor?.Invoke(_floor);
        }
    }
}
