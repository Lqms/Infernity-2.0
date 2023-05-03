using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State _targetState;

    protected PlayerController PlayerController;

    public State TargetState => _targetState;
    public bool NeedTransit { get; protected set; }

    private void Awake()
    {
        PlayerController = GetComponentInParent<PlayerController>();
    }

    private void OnEnable()
    {
        NeedTransit = false;
    }
}
