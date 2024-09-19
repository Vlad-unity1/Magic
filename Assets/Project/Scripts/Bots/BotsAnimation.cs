using UnityEngine;

public class BotsAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void OnBotMove()
    {
        _animator.SetBool("IsRunning", true);
    }

    public void OnBotStop()
    {
        _animator.SetBool("IsRunning", false);
    }

    public void OnBotAttack()
    {
        _animator.SetTrigger("IsAttack");
    }
}

