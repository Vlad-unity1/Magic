using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BulletFire : Bullet
{
    private FireBulletObserver _particleSystem;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _aoeDamage;
    [SerializeField] private float _periodicalDamage;

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

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, _explosionRadius);

        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.transform == hitTarget)
                continue;

            if (hitCollider.TryGetComponent(out TargetTakeDamage target))
            {
                target.TakeDamage(_aoeDamage);
                StartCoroutine(FirePeriodicalDamage(hitCollider.transform));
                _particleSystem.FireEffectRoutine(hitCollider.transform.position);
                Debug.Log($"Нанесено {_aoeDamage} AOE урона таргету : {target.name}");
            }
        }
    }

    private IEnumerator FirePeriodicalDamage(Transform transform)
    {
        if(transform.TryGetComponent(out TargetTakeDamage targetTakeDamage))
        {
                targetTakeDamage.TakeDamage(_periodicalDamage);
                Debug.Log($"Нанесено {_periodicalDamage} Переодического урона таргету : {transform.name}");
                yield return new WaitForSeconds(2f);
        }
    }
}
