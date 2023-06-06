using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Portal : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject _portalVFX;

    public static event UnityAction<GameObject> Entered;

    public void Use()
    {
        var enteredPortal = Instantiate(_portalVFX);
        Entered?.Invoke(enteredPortal);
    }
}
