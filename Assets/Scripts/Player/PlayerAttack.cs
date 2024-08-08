using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Bullet _bulletPrefab;

    private void Start()
    {
        _bulletPrefab = GetComponent<Bullet>();
    }

    private void FixedUpdate()
    {
        if (_bulletPrefab.BulletObj == null)
        {
            _bulletPrefab.Cast();
        }
    }
}
