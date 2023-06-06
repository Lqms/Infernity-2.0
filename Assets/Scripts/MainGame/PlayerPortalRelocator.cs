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

    private void OnPortalEntered(GameObject enteredPortal)
    {
        print("entererd");
        var room = _roomsManager.GetRandomRoom();
        _player.PrepareForTeleportation();

        _player.transform.position = room.EntryPoint.position;
        _player.transform.localEulerAngles = room.EntryPoint.eulerAngles;

        enteredPortal.transform.parent = room.EntryPoint;
        enteredPortal.transform.localPosition = Vector3.zero - new Vector3(0, 0, 1);
        enteredPortal.transform.localEulerAngles = Vector3.zero;

        StartCoroutine(PortalClosing(enteredPortal));

        _player.EndTeleportation();
    }

    private IEnumerator PortalClosing(GameObject enteredPortal)
    {
        float animationSpeed = 1;

        while (enteredPortal.transform.localScale != Vector3.zero)
        {
            enteredPortal.transform.localScale = Vector3.MoveTowards(enteredPortal.transform.localScale, Vector3.zero, Time.deltaTime * animationSpeed);

            yield return null;
        }
    }
}
