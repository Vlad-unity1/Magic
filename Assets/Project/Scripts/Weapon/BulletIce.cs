using UnityEngine;

public class BulletIce : Bullet
{
    private TargetWeapon _weapon;
    private FireBulletObserver _particleSystem;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _aoeDamage;

    private void Start()
    {
        _particleSystem = GetComponent<FireBulletObserver>();
        _weapon = FindObjectOfType<TargetWeapon>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out TargetTakeDamage target) || other.gameObject.TryGetComponent(out PlayerTakeDamage player))
        {
            ApplyDirectDamage(other.transform);
            Explode(other.transform);
            _weapon.UpdateBotsBullet();
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
        else if (target.TryGetComponent(out PlayerTakeDamage playerDamage))
        {
            playerDamage.TakeDamage(_damage);
            Debug.Log($"Нанесено {_damage} урона игроку: {target.name}");
        }
    }

    private void Explode(Transform hitTarget)
    {
        _particleSystem.OnExplosionPlayLightning(transform.position);

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, _explosionRadius);

        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.transform == hitTarget)
                continue;

            if (hitCollider.TryGetComponent(out TargetTakeDamage target))
            {
                target.TakeDamage(_aoeDamage);
                _particleSystem.PlayLightningEffectOnTarget(hitCollider.transform.position);
                Debug.Log($"Нанесено {_aoeDamage} AOE урона таргету : {target.name}"); // дебаги для проверки работает ли как надо. Надо сдвигать ботов вместе, отключая TargetWeapon. 
            }
            else if (hitCollider.TryGetComponent(out PlayerTakeDamage player))
            {
                player.TakeDamage(_aoeDamage);
                Debug.Log($"Нанесено {_aoeDamage} AOE урона игроку: {player.name}");
            }
        }
    }
}