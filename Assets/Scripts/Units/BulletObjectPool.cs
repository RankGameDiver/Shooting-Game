using System.Collections.Generic;
using UnityEngine;

public class BulletObjectPool : MonoSingleton<BulletObjectPool>
{
    private List<Bullet> _enableBullets = new List<Bullet>();
    private Queue<Bullet> _disableBullets = new Queue<Bullet>();

    public void Spawn(Bullet.Settings bulletSettings, Vector3 startPos)
    {
        // Debug.Log("Spawn Bullet");
        Bullet bullet;
        if(_disableBullets.Count > 0)
        {
            bullet = _disableBullets.Dequeue();
            bullet.transform.position = startPos;
        }
        else
        {
            GameObject bulletObj = new GameObject("bullet");
            bulletObj.transform.SetPositionAndRotation(startPos, Quaternion.identity);
            bulletObj.transform.parent = gameObject.transform;
            bulletObj.AddComponent<SpriteRenderer>();
            bulletObj.AddComponent<BoxCollider2D>();
            bullet = bulletObj.AddComponent<Bullet>();
        }

        bullet.Init(bulletSettings);
        bullet.gameObject.SetActive(true);

        _enableBullets.Add(bullet);
    }

    public void Dispawn(Bullet bullet)
    {
        _enableBullets.Remove(bullet);
        _disableBullets.Enqueue(bullet);
    }
}