using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BulletRepository : MonoBehaviour
{
    [SerializeField] private List<Bullet> _bullets;

    public Bullet Get(BulletType bulletType)
    {
        Bullet bullet = _bullets.FirstOrDefault(item => item.Type == bulletType);

        if (bullet != null)
        {
            return bullet;
        }
        else
        {
            throw new NullReferenceException("No bullet Type");
        }
    }
}
