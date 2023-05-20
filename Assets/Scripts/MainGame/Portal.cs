using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Portal : MonoBehaviour, IInteractable
{
    public static event UnityAction Entered;

    public void Use()
    {
        Entered?.Invoke();
    }
}
