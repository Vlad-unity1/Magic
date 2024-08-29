using UnityEngine;

public class CrystallExp : MonoBehaviour
{
    [SerializeField] private int _expCrystall = 5;
    [SerializeField] GameObject _gameObject;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out PlayerLvlUpgrade _player))
        {
            _gameObject.SetActive(false);
            _player._expPlayer += _expCrystall;
            Debug.Log($"{_player._expPlayer}");
        }
    }

}
