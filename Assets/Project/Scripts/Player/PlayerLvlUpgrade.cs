using UnityEngine;

public class PlayerLvlUpgrade: MonoBehaviour
{
    public int PlayerLvl {  get; private set; }
    public int ExpPlayer { get; private set; }
    private Weapon _weapon;

    private void Start()
    {
        _weapon = GetComponent<Weapon>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out CrystallExp _crystal))
        {
            ExpPlayer += _crystal.Exp;
            _crystal.OnInteract();

            if (ExpPlayer == 20)
            {
                PlayerLvl = 1;
                if (PlayerLvl >= 1)
                {
                    _weapon.CheckCurrentBullet();
                }
            }
        }
    }
}
