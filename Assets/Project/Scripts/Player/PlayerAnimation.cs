using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void OnPlayerMove()
    {
        _animator.SetBool("IsRunning", true);
    }

    public void OnPlayerStop()
    {
        _animator.SetBool("IsRunning", false);
    }

    public void OnPlayerAttack()
    {
        _animator.SetTrigger("IsAttack");
    }
}
