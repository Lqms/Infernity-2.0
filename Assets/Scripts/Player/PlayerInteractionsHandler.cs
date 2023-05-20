using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionsHandler : MonoBehaviour
{
    private IInteractable _closestInteractableObject;

    private void OnEnable()
    {
        PlayerInput.InteractKeyPressed += OnInteractKeyPressed;
    }

    private void OnDisable()
    {
        PlayerInput.InteractKeyPressed -= OnInteractKeyPressed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IInteractable intetactableObject))
        {
            _closestInteractableObject = intetactableObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IInteractable intetactableObject))
        {
            _closestInteractableObject = null;
        }
    }

    private void OnInteractKeyPressed()
    {
        if (_closestInteractableObject != null)
            _closestInteractableObject.Use();
    }
}
