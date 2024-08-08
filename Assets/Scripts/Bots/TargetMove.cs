using UnityEngine;
using UnityEngine.AI;

public class TargetMove : MonoBehaviour
{
    [SerializeField] private PlayerMovement _player;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private GameObject[] _targets;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        MoveToPlayer();
    }

    private void MoveToPlayer()
    {
        var distanceToPlayer = Vector3.Distance(_player.transform.position, _agent.transform.position);
        Transform nearestTarget = null;
        float nearestTargetDistance = float.MaxValue;

        if (distanceToPlayer > 15)
        {
            foreach (var target in _targets)
            {
                var distanceToTarget = Vector3.Distance(_agent.transform.position, target.transform.position);
                if (distanceToTarget < nearestTargetDistance)
                {
                    nearestTargetDistance = distanceToTarget;
                    nearestTarget = target.transform;
                }
            }

            if (nearestTarget != null)
            {
                _agent.destination = nearestTarget.position;
                Vector3 directionToTarget = nearestTarget.position - _agent.transform.position;
                _agent.transform.rotation = Quaternion.LookRotation(directionToTarget);
            }
        }
        else
        {
            _agent.destination = _player.transform.position;
            Vector3 directionToPlayer = _player.transform.position - _agent.transform.position;
            _agent.transform.rotation = Quaternion.LookRotation(directionToPlayer);
        }
    }
}
