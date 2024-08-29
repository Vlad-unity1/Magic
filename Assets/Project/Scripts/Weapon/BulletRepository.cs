using System;
using System.Collections.Generic;
using UnityEngine;

public class BulletRepository : MonoBehaviour
{
    [SerializeField] private List<Bullet> _bullets;

    public Bullet Get(BulletType bulletType)
    {
        Bullet bullet = null;

        foreach (var item in _bullets)
        {
            if(item.Type == bulletType)
                bullet = item;
        }

        if (bullet != null)
        {
            return bullet;
        }
        else
        {
            throw new NullReferenceException();
        }
    }
}
