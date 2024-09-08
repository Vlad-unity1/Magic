using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemyFire : Bullet
{
    private FireBulletObserver _particleSystem;
    private TargetWeapon _weapon;

    private void Start()
    {
        _particleSystem = GetComponent<FireBulletObserver>();
    }
    public void SetWeapon(TargetWeapon weapon)
    {
        _weapon = weapon;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out TargetTakeDamage _target))
        {
            _particleSystem.OnExplosionPlayFire(transform.position);
            _target.TakeDamage(_damage);
            _weapon.UpdateBotsBullet();
            Destroy(gameObject);
        }
    }
}
