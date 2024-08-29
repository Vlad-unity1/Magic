using UnityEngine;

public class PlayerLvlUpgrade: MonoBehaviour
{
    public int _playerLvl = 0;
    public int _expPlayer = 0;
    private Weapon _weapon;

    private void Start()
    {
        _weapon = GetComponent<Weapon>();
    }

    private void Update()
    {
        if (_expPlayer == 20)
        {
            _playerLvl = 1;
            if (_playerLvl >= 1)
            {
                _weapon.CheckCurrentBullet();
            }
        }
    }
}
