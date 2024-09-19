using UnityEngine;

[System.Serializable]
public class BulletLevel
{
    public int level;
    public Bullet bulletPrefab; 
}

public class BulletManager : MonoBehaviour
{
    public BulletLevel[] bulletLevels;
    private Bullet currentBullet; 

    public void SetBulletByLevel(int level)
    {
        foreach (var bulletLevel in bulletLevels)
        {
            if (bulletLevel.level == level)
            {
                currentBullet = bulletLevel.bulletPrefab;
                return;
            }
        }
    }

    public Bullet GetCurrentBullet()
    {
        return currentBullet;
    }
}