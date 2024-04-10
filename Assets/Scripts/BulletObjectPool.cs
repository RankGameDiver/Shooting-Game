using System.Collections.Generic;
using UnityEngine;

public class BulletObjectPool : MonoBehaviour
{
    private static BulletObjectPool _instance;

    public static BulletObjectPool Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<BulletObjectPool>();

                if (_instance == null)
                {
                    GameObject obj = new("BulletObjectPool");
                    _instance = obj.AddComponent<BulletObjectPool>();
                }
            }

            return _instance;
        }
    }

    [SerializeField] private GameObject _bulletObj;
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
            var bulletObj = Instantiate(_bulletObj, startPos, Quaternion.identity, gameObject.transform);
            bulletObj.name = "bullet";
            bullet = bulletObj.GetComponent<Bullet>();
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