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

    private void OnEnable()
    {
        ActiveCoroutine = null;
        Animator = GetComponent<Animator>();
        Animator.SetTrigger(_animationName.ToString());
        BaseAnimationTime = Animator.GetCurrentAnimatorStateInfo(0).length;
    }

    protected void Complete()
    {
        ActiveCoroutine = null;
        ActionCompleted?.Invoke();
    }
}
