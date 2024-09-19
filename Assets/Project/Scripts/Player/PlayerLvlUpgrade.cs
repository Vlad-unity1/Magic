using UnityEngine;

public class PlayerLvlUpgrade: MonoBehaviour
{
    public int ExpPlayer { get; private set; }
    public BulletManager bulletManager;
    public int level;

    private void Start()
    {
        bulletManager = GetComponent<BulletManager>();
        level = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out CrystallExp _crystal))
        {
            bulletManager.SetBulletByLevel(level);
            ExpPlayer += _crystal.Exp;
            _crystal.OnInteract();

            if (ExpPlayer == 20)
            {
                level = 1;
                if (level >= 1)
                {
                    LevelUp();
                }
            }
        }
    }

    public void LevelUp()
    {
        Debug.Log($"Текущий: {level}");
        bulletManager.SetBulletByLevel(level);
    }
}
