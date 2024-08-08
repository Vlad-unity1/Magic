using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetAttack : MonoBehaviour
{
    private Bullet bulletPrefab;

    private void Start()
    {
        bulletPrefab = GetComponent<Bullet>();
    }

    private void FixedUpdate()
    {
        if (bulletPrefab.BulletObj == null)
        {
            bulletPrefab.Cast();
        }
    }
}
