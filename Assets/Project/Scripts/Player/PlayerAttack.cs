using UnityEngine;

public class PlayerLvlUpgrade: MonoBehaviour
{
    private Player _playerStats;
    private Weapon _weapon;

    private void Start()
    {
        _playerStats = GetComponent<Player>();
        _weapon = GetComponent<Weapon>();
    }

    private void Update()
    {
        if (_playerStats._expPlayer == 20)
        {
            _playerStats._playerLvl = 1;
            if (_playerStats._playerLvl >= 1)
            {
                _weapon.CheckCurrentBullet();
            }
        }
    }
}
