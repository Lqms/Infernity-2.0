using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private Transform _entryPoint;

    public Vector3 EntryPointPosition => _entryPoint.position;
}
