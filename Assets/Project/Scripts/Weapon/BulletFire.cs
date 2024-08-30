using System.Collections;
using UnityEngine;

public class BulletFire : Bullet
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out TargetTakeDamage target))
        {
            target.TakeDamage(_damage);
        }
        Destroy(gameObject);
    }
}
