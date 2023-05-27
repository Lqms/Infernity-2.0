using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPortalRelocator : MonoBehaviour
{
    [SerializeField] private RoomsManager _roomsManager;
    [SerializeField] private PlayerController _player;

    private void OnEnable()
    {
        Portal.Entered += OnPortalEntered;
    }

    private void OnDisable()
    {
        Portal.Entered -= OnPortalEntered;
    }

    private void OnPortalEntered()
    {
        print("entererd");
        var room = _roomsManager.GetRandomRoom();
        _player.PrepareForTeleportation();
        _player.transform.position = room.EntryPointPosition;
        _player.EndTeleportation();
    }
}
