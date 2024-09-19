using System.Diagnostics;
using UnityEngine;

public class DefaultBullet : Bullet
{
    public override void OnHitEnemy(TargetTakeDamage enemy)
    {
        enemy.TakeDamage(damage);
        UnityEngine.Debug.Log($"{damage}");
    }
}
