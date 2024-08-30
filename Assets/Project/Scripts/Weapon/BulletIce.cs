using System.Collections;
using UnityEngine;

public class BulletIce : Bullet
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