using System.Collections;
using UnityEngine;

public class BulletFire : Bullet
{
    private FireBulletObserver _particleSystem;
    [SerializeField] private float explosionRadius;
    [SerializeField] private float aoeDamage;

    private void Start()
    {
        _particleSystem = GetComponent<FireBulletObserver>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out TargetTakeDamage target))
        {
            ApplyDirectDamage(other.transform);
            Explode(other.transform);
            Destroy(gameObject);
        }
    }

    private void ApplyDirectDamage(Transform target)
    {
        if (target.TryGetComponent(out TargetTakeDamage targetDamage))
        {
            targetDamage.TakeDamage(_damage);
            Debug.Log($"Нанесено {_damage} урона по таргету: {target.name}");
        }
    }

    private void Explode(Transform hitTarget)
    {
        _particleSystem.OnExplosionPlayFire(transform.position);

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.transform == hitTarget)
                continue;

            if (hitCollider.TryGetComponent(out TargetTakeDamage target))
            {
                target.TakeDamage(aoeDamage);
                _particleSystem.FireEffectRoutine(hitCollider.transform.position);
                Debug.Log($"Нанесено {aoeDamage} AOE урона таргету : {target.name}");
            }
        }
    }
}
