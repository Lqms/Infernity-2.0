using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerMovement _movement;
    [SerializeField] private PlayerStats _stats;

    private void OnEnable()
    {
        PlayerInput.AttackKeyPressed += OnAttackKeyPressed;
        PlayerInput.MoveKeyPressed += OnMoveKeyPressed;
    }


    private void OnDisable()
    {
        PlayerInput.AttackKeyPressed -= OnAttackKeyPressed;
        PlayerInput.MoveKeyPressed -= OnMoveKeyPressed;
    }

    private void OnAttackKeyPressed()
    {

    }

    private void OnMoveKeyPressed()
    {
        _movement.TryMove(GetClickedPoint(), _stats.Speed);
    }

    private Vector3 GetClickedPoint()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit clickedPointInfo);
        Vector3 clickedPoint = new Vector3(clickedPointInfo.point.x, transform.position.y, clickedPointInfo.point.z);

        return clickedPoint;
    }
}
