public class ElectricBullet : Bullet
{
    public override void OnHitEnemy(TargetTakeDamage enemy)
    {
        enemy.TakeDamage(damage);
    }
}