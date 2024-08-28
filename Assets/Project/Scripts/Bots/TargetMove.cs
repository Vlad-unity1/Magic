using UnityEngine;
using UnityEngine.AI;

public class TargetMove : MonoBehaviour
{
    [SerializeField] private PlayerMovement _player;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private GameObject[] _targets;
    private float _nextUpdate;
    private float _updateRate = 1f;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Time.time >= _nextUpdate)
        {
            _nextUpdate = Time.time + _updateRate;

            var distanceToPlayer = Vector3.Distance(_player.transform.position, _agent.transform.position);

            if (distanceToPlayer > 15)
            {
                MoveToNearestTarget();
            }
            else
            {
                MoveToPosition(_player.transform.position);
            }
        }
    }

    private void MoveToNearestTarget()
    {
        Transform nearestTarget = null;
        float nearestTargetDistance = float.MaxValue;

        foreach (var target in _targets)
        {
            if (target == null) continue;

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
}
