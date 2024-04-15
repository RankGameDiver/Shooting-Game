using UnityEngine;
/// <summary>
/// 유닛 무기 관리 코드
/// </summary>
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

    // 무기 발사 위치 설정
    public void SetPosition(Vector3 startPos)
    {
        _startPos = startPos;
    }

    // 총알 생성
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