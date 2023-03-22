using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
public class State : MonoBehaviour
{
    [SerializeField] private bool _canBeInterrupted;
    [SerializeField] private AnimationNames _animationName;

    protected Animator Animator;
    protected Coroutine ActiveCoroutine;
    protected float BaseAnimationTime;

    public bool CanBeInterrupted => _canBeInterrupted;

    public event UnityAction ActionCompleted;

    public void Init()
    {
        Animator = GetComponent<Animator>();
        Animator.SetTrigger(_animationName.ToString());
        BaseAnimationTime = Animator.GetCurrentAnimatorStateInfo(0).length;
        enabled = false;
    }

    public void Enter()
    {
        ActiveCoroutine = null;
        Animator.SetTrigger(_animationName.ToString());
    }

    protected void Complete()
    {
        ActiveCoroutine = null;
        ActionCompleted?.Invoke();
    }
}
