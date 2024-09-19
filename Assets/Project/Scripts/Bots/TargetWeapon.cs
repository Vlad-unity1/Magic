using System.Collections;
using UnityEngine;

public class TargetWeapon : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _force;
    [SerializeField] private float _attackSpeed;
    [SerializeField] private BotsAnimation _botAnimation;
    private Bullet _currentBullet;
    private Coroutine _routine;
    private int _level = 0;
    private int _lvlMax = 1;

    
    private void Start()
    {
        StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        WaitForSeconds cooldown = new WaitForSeconds(_attackSpeed);
        while (true)
        {
            _botAnimation.OnBotAttack();
            yield return new WaitForSeconds(0.25f);
            Cast(_firePoint);
            yield return cooldown;
        }
    }

    private void Cast(Transform firePoint)
    {
        var bulletOriginal = Instantiate(_currentBullet, firePoint.position, firePoint.rotation);
        bulletOriginal.Run(firePoint.transform.forward * _force);
    }

    public void UpdateBotsBullet()
    {
        _routine = StartCoroutine(CheckBotsLevelRoutine(10));
    }

    private IEnumerator CheckBotsLevelRoutine(float timeInSec)
    {
        yield return new WaitForSeconds(timeInSec);
        if (_level < _lvlMax)
        {
            _level++;
            Debug.Log($"Уровень увеличен: {_level}");
        }
        else
        {
            Debug.Log($"Max lvl");
        }
    }
}
