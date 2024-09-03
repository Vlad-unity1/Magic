using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : Bullet
{
    private TargetWeapon _weapon;

    public void SetWeapon(TargetWeapon weapon)
    {
        _weapon = weapon;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out TargetTakeDamage _target))
        {
            _target.TakeDamage(_damage);
            _weapon.UpdateBotsBullet();
        } 
    }
}
