using System;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class PlayerFacade : MonoBehaviour
{
    [Serializable]
    private class Settings
    {
        public float MoveAnimTime = 0.03f;
        public float MoveSpeed = 0.02f;
        public float ShootingCoolTime = 0.2f;
    }

    private PlayerAnimation _animation;
    private PlayerInput _input;
    private PlayerMovement _movement;
    private PlayerWeaponSystem _weaponSystem;

    [SerializeField] private Bullet.Settings _bulletSettings;
    [SerializeField] private Settings _settings;

    void Awake() 
    {
        SpriteResolver spriteResolver = GetComponentInChildren<SpriteResolver>();
        _animation = new PlayerAnimation(spriteResolver);
        _animation.SetUpdateTime(_settings.MoveAnimTime);

        _input = GetComponentInChildren<PlayerInput>();
        _input.Init(this);

        _movement = new PlayerMovement(_settings.MoveSpeed, gameObject);
        _weaponSystem = new PlayerWeaponSystem(_bulletSettings, gameObject.transform.position, _settings.ShootingCoolTime);
    }

    void Update() 
    {
        _movement.OnUpdate();
        _animation.SetDirectionX(_movement.GetDirection().x);
        _animation.OnUpdate();

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
