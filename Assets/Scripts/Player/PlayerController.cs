using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerCombat _combat;
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private Animator _animator;

    public bool IsAttacking => _combat.IsAttacking;
    public bool IsCasting => _combat.IsCasting;
    public bool IsBlocking => _combat.IsBlocking;
    public bool IsMovementStopped => _mover.IsMovementStopped;
    
    public void Block()
    {
        _mover.StopMovement();
        _combat.Block();
    }

    public void UnBlock()
    {
        _combat.UnBlock();
    }
    
    public void Attack(Vector3 point)
    {
        _mover.StopMovement();
        _combat.Attack(_animator);
    }

    public void Cast(Vector3 point)
    {
        _mover.StopMovement();
        transform.DORotate(point, 0.2f);
        _combat.Cast();
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

    public void PrepareForTeleportation()
    {
        _mover.StopMovement();
        GetComponent<NavMeshAgent>().enabled = false;
    }

    public void EndTeleportation()
    {
        GetComponent<NavMeshAgent>().enabled = true;
        _mover.StopMovement();
    }

    private void Update()
    {
        print(IsMovementStopped);
    }
}
