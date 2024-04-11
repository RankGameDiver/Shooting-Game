using UnityEngine;

public class WeaponSystem
{
    private Bullet.Settings _bulletSettings;
    private Vector3 _startPos;
    private float _curTime;
    private float _coolTime;

    public WeaponSystem(Bullet.Settings bulletSettings, Vector3 startPos, float coolTime)
    {
        _bulletSettings = bulletSettings;
        _startPos = startPos;
        _coolTime = coolTime;
    }

    public void SetPosition(Vector3 startPos)
    {
        _startPos = startPos;
    }

    public void CreateBullet()
    {
        _curTime += Time.deltaTime;
        if(_curTime >= _coolTime)
        {
            _curTime = 0;
            BulletObjectPool.Instance.Spawn(_bulletSettings, _startPos);
        }
    }
}