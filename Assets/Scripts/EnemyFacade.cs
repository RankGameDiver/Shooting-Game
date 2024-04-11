using System;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class EnemyFacade : MonoBehaviour
{
    [Serializable]
    private class Settings
    {
        public float MoveAnimTime = 0.03f;
        public float MoveSpeed = 0.02f;
        public float ShootingCoolTime = 0.2f;
    }

    private Movement _movement;
    private WeaponSystem _weaponSystem;

    [SerializeField] private Bullet.Settings _bulletSettings;
    [SerializeField] private Settings _settings;

    void Awake() 
    {
        SpriteResolver spriteResolver = GetComponentInChildren<SpriteResolver>();
        // _animation = new PlayerAnimation(spriteResolver);
        // _animation.SetUpdateTime(_settings.MoveAnimTime);

        _movement = new Movement(_settings.MoveSpeed, gameObject);
        _weaponSystem = new WeaponSystem(_bulletSettings, gameObject.transform.position, _settings.ShootingCoolTime);
    }

    void Update() 
    {
        _movement.OnUpdate();
        // _animation.SetDirectionX(_movement.GetDirection().x);
        // _animation.OnUpdate();

        _weaponSystem.SetPosition(gameObject.transform.position);
        _weaponSystem.CreateBullet();
    }

    public void OnFoward(bool isPressed)
    {
        _movement.SetDirectionX(isPressed);
    }

    public void OnBack(bool isPressed)
    {
        _movement.SetDirectionX(!isPressed);
    }

    public void OnLeft(bool isPressed)
    {
        _movement.SetDirectionY(!isPressed);
    }

    public void OnRight(bool isPressed)
    {
        _movement.SetDirectionY(isPressed);
    }
}
