using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsManager : MonoBehaviour
{
    [SerializeField] private Room[] _rooms;

    public Room GetRandomRoom()
    {
        return _rooms[Random.Range(0, _rooms.Length)];
    }
 }
