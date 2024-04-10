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
    private List<Bullet> _bullets = new List<Bullet>();

    public void Spawn(Bullet.Settings bulletSettings, Vector3 startPos)
    {
        // Debug.Log("Spawn Bullet");
        var bulletObj = Instantiate(_bulletObj, startPos, Quaternion.identity, gameObject.transform);
        bulletObj.name = "bullet";

        Bullet bullet = bulletObj.GetComponent<Bullet>();
        bullet.Init(bulletSettings);
        _bullets.Add(bullet);
    }
}