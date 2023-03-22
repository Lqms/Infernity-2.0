using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("States")]
    [SerializeField] private MovementState _movementState;
    [SerializeField] private BlockState _blockState;
    [SerializeField] private CombatState _combatState;
    [SerializeField] private CastSpellState _castState;
    [SerializeField] private IdleState _idleState;

    private State _currentState;

    private void OnEnable()
    {
        PlayerInput.RightMouseButtonClicked += OnRightMouseButtonClicked;
        PlayerInput.LeftMouseButtonClicked += OnLeftMouseButtonClicked;
        PlayerInput.BlockKeyPressed += OnBlockKeyPressed;
        PlayerInput.CastSpellKeyPressed += OnCastSpellKeyPressed;
    }

    private void OnDisable()
    {
        PlayerInput.RightMouseButtonClicked -= OnRightMouseButtonClicked;
        PlayerInput.LeftMouseButtonClicked -= OnLeftMouseButtonClicked;
        PlayerInput.BlockKeyPressed -= OnBlockKeyPressed;
        PlayerInput.CastSpellKeyPressed -= OnCastSpellKeyPressed;
    }

    private void Start()
    {
        var states = GetComponents<State>();

        foreach (var state in states)
        {
            state.Init();
        }

        _currentState = _idleState;
        _currentState.enabled = true;
        _currentState.Enter();
    }

    private void OnCastSpellKeyPressed()
    {
        if (TryChangeState(_castState))
            _castState.Cast();
    }

    private void OnActionCompleted()
    {
        ChangeState(_idleState);
    }

    private bool TryChangeState(State newState)
    {
        if (_currentState.CanBeInterrupted == false)
            return false;

        ChangeState(newState);

        return true;
    }

    private void ChangeState(State newState)
    {
        if (newState == _currentState)
            return;

        _currentState.ActionCompleted -= OnActionCompleted;
        _currentState.enabled = false;

        _currentState = newState;

        _currentState.enabled = true;
        _currentState.Enter();
        _currentState.ActionCompleted += OnActionCompleted;
    }

    private void OnRightMouseButtonClicked()
    {
        if (TryChangeState(_movementState))
            _movementState.TryMoveToPoint(HandleClick().point);
    }

    private void OnLeftMouseButtonClicked()
    {
        if (TryChangeState(_combatState))
            _combatState.AttackToPoint(HandleClick().point);
    }

    private void OnBlockKeyPressed(KeyCode key)
    {
        if (TryChangeState(_blockState))
            _blockState.Block(key);
    }

    private RaycastHit HandleClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit hitInfo);

        return hitInfo;
    }
}
