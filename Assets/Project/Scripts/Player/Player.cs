using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public int _expPlayer = 0;
    [SerializeField] public int _playerLvl = 0;

    private void FixedUpdate()
    {
        if(_expPlayer == 20)
        {
            _playerLvl = 1;
            if(_playerLvl >= 1)
            {
                
            }
        }
        if(_expPlayer == 30)
        {
            _playerLvl = 2;
            if(_playerLvl == 2)
            {
               
            }
        }
    }
}
