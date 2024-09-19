using UnityEngine;
public class FireBullet : Bullet
{
    public override void OnHitEnemy(TargetTakeDamage enemy)
    {      
        enemy.TakeDamage(damage);
        Debug.Log($" Fire: {damage}");
    }
}