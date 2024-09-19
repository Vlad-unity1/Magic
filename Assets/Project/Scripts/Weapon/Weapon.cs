using System.Collections;
using UnityEngine;


public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _force;
    [SerializeField] private float _attackSpeed;
    [SerializeField] private PlayerAnimation _playerAnimation;
    [SerializeField] private Bullet _currentBullet;
    [SerializeField] private BulletManager bulletManager;
    private PlayerLvlUpgrade _playerLvlUpgrade;

    private void Start()
    {
        _playerLvlUpgrade = GetComponent<PlayerLvlUpgrade>();
        StartCoroutine(Attack());
    }
    private void Update()
    {
        bulletManager.SetBulletByLevel(_playerLvlUpgrade.level);     
    }
    private IEnumerator Attack()
    {
        WaitForSeconds cooldown = new WaitForSeconds(_attackSpeed);
        while (true)
        {
            _playerAnimation.OnPlayerAttack();
            yield return new WaitForSeconds(0.25f);
            Cast(_firePoint);
            yield return cooldown;
        }
    }

    private void Cast(Transform firePoint)
    {
        _currentBullet = bulletManager.GetCurrentBullet();
        var bulletInstance = Instantiate(_currentBullet, firePoint.position, firePoint.rotation);
        bulletInstance.Run(firePoint.transform.forward * _force);
        bulletInstance.damage = _currentBullet.damage;
        bulletInstance.radius = _currentBullet.radius;
    }
}
