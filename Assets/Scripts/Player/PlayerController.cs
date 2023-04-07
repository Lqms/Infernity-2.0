using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerCombat _combat;
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private Animator _animator;

    public bool IsAttacking => _combat.IsAttacking;
    public bool IsMovementStopped => _mover.IsMovementStopped;
    
    public void Attack(Vector3 point)
    {
        _mover.StopMovement();
        transform.DORotate(point, 0.2f); // не хочет поворачиваться в точку атаки, гад
        _combat.Attack();
    }

    public void Move(Vector3 point)
    {
        _mover.Move(point);
    }
    
    public void PlayAnimation(string animationName)
    {
        _animator.Play(animationName);
    }

    public void StopAnimatorPlayback()
    {
        _animator.StopPlayback();
    }
    
    public RaycastHit HandleClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit hitInfo);

        return hitInfo;
    }
}
