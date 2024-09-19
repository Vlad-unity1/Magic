public class FrostBullet : Bullet
{
    public override void OnHitEnemy(TargetTakeDamage enemy)
    {
        enemy.TakeDamage(damage);
    }
}