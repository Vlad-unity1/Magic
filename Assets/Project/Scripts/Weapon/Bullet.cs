using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Bullet : MonoBehaviour
{
    [field: SerializeField] public float TimerLive { get; private set; }
    [field: SerializeField] private Rigidbody _rb;
    public float damage;
    public float radius;

    public abstract void OnHitEnemy(TargetTakeDamage enemy);

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        Destroy(gameObject, TimerLive);
    }

    public void Run(Vector3 force)
    {
        _rb.AddForce(force, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider enemyCollider)
    {
        Destroy(gameObject);
    }
}
