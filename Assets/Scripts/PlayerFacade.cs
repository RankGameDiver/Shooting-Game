using UnityEngine.U2D.Animation;

public class PlayerFacade : UnitFacade
{
    private PlayerAnimation _animation;
    private PlayerInput _input;

    void Awake() 
    {
        SpriteResolver spriteResolver = GetComponentInChildren<SpriteResolver>();
        _animation = new PlayerAnimation(spriteResolver, _settings.TimeperFrame);

        _input = GetComponentInChildren<PlayerInput>();
        _input.Init(this);

        _movement = new Movement(_settings.MoveSpeed, gameObject);
        _weaponSystem = new WeaponSystem(_bulletSettings, gameObject.transform.position, _settings.ShootingCoolTime);
        _status = new Status(_settings.MaxLife);

        _collisionListener = GetComponent<CollisionListener>();
        _collisionListener.Init(this, gameObject.tag);
    }

    void Update() 
    {
        _movement.OnUpdate();
        _animation.SetDirectionX(_movement.GetDirection().x);
        _animation.OnUpdate();
        _weaponSystem.SetPosition(gameObject.transform.position);
        _weaponSystem.CreateBullet();
    }

    public override void OnFoward(bool isPressed)
    {
        _movement.SetDirectionX(isPressed);
    }

    public override void OnBack(bool isPressed)
    {
        _movement.SetDirectionX(!isPressed);
    }

    public override void OnLeft(bool isPressed)
    {
        _movement.SetDirectionY(!isPressed);
    }

    public override void OnRight(bool isPressed)
    {
        _movement.SetDirectionY(isPressed);
    }

    public override void OnHit()
    {
        base.OnHit();
    }
}
