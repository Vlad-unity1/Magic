using UnityEngine;
using UnityEngine.AI;

public class TargetMove : MonoBehaviour
{
    [SerializeField] private PlayerMovement _player;
    [SerializeField] private PlayerTakeDamage _playerTakeDamage;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private GameObject[] _targets;
    [SerializeField] private BotsAnimation _botAnimation;
    private float _nextUpdate;
    private float _updateRate = 1f;

    private void Update()
    {
        if (Time.time >= _nextUpdate)
        {
            _nextUpdate = Time.time + _updateRate;
            if (_playerTakeDamage._currentHealth <= 0)
            {
                MoveToNearestTarget();
            }
            else
            {
                var distanceToPlayer = Vector3.SqrMagnitude(_player.transform.position - _agent.transform.position);

                if (distanceToPlayer > 15 * 15)
                {
                    MoveToNearestTarget();
                }
                else
                {
                    MoveToPosition(_player.transform.position);
                }
            }
        }
        UpdateBotAnimation();
    }

    private void MoveToNearestTarget()
    {
        Transform nearestTarget = null;
        float nearestTargetDistance = float.MaxValue;

        foreach (var target in _targets)
        {
            if (target == null) 
                continue;

            var distanceToTarget = Vector3.Distance(_agent.transform.position, target.transform.position);
            if (distanceToTarget < nearestTargetDistance)
            {
                nearestTargetDistance = distanceToTarget;
                nearestTarget = target.transform;
            }
        }

        if (nearestTarget != null)
        {
            MoveToPosition(nearestTarget.position);
        }
    }

    private void MoveToPosition(Vector3 position)
    {
        _agent.destination = position;
        Vector3 direction = position - _agent.transform.position;
        _agent.transform.rotation = Quaternion.LookRotation(direction);
    }

    private void UpdateBotAnimation()
    {
        if (_agent.velocity.sqrMagnitude > 0.1f) 
        {
            _botAnimation.OnBotMove(); 
        }
        else
        {
            _botAnimation.OnBotStop();
        }
    }
}
