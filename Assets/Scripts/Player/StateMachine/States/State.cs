using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimationNames
{
    Attack,
    Idle,
    Run,
}

public class State : MonoBehaviour
{
    [SerializeField] private AnimationNames _animationName;
    [SerializeField] private List<Transition> _transitions;

    protected PlayerController PlayerController;

    private void Awake()
    {
        PlayerController = GetComponentInParent<PlayerController>();
    }

    protected virtual void OnEnable()
    {
        PlayerController.PlayAnimation(_animationName.ToString());
    }

    protected virtual void OnDisable()
    {
        PlayerController.StopAnimatorPlayback();
    }

    public void Enter()
    {
        if (enabled == false)
        {
            enabled = true;

            foreach (var transition in _transitions)
                transition.enabled = true;
        }
    }

    public void Exit()
    {
        if (enabled == true)
        {
            foreach (var transition in _transitions)
                transition.enabled = false;

            enabled = false;
        }
    }

    public State TryGetNextState()
    {
        foreach (var transition in _transitions)
        {
            if (transition.NeedTransit)
                return transition.TargetState;
        }

        return null;
    }
}
