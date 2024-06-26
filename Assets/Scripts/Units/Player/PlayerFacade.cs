using UnityEngine;
using UnityEngine.U2D.Animation;

public class PlayerFacade : UnitFacade
{
    private PlayerAnimation _animation;
    private PlayerInput _input;
    private PlayerHeartController _heartController;

    private Movement _movement;
    private PlayerBooster _booster;
    [SerializeField] private PlayerBooster.Settings _boosterSettings;

    void Awake() 
    {
        SpriteResolver spriteResolver = GetComponentInChildren<SpriteResolver>();
        _animation = new PlayerAnimation(spriteResolver, _settings.TimeperFrame);

        _input = GetComponentInChildren<PlayerInput>();
        _input?.Init(this);

        _booster = new PlayerBooster(_boosterSettings);
        _movement = new Movement(_settings.MoveSpeed, gameObject);
        _weaponSystem = new WeaponSystem(_bulletSettings, gameObject.transform.position, _settings.ShootingCoolTime);
        _status = new Status(_settings.MaxLife);

        _collisionListener = GetComponent<CollisionListener>();
        _collisionListener?.Init(this, gameObject.tag);

        _isActive = true;
    }

    void FixedUpdate() 
    {
        if(!_isActive)
        {
            return;
        }

        _booster.OnUpdate();
        _movement.OnUpdate(_booster.GetSpeedRate());
        _animation.SetDirectionX(_movement.GetDirection().x);
        _animation.OnUpdate();
        _weaponSystem.SetPosition(gameObject.transform.position);
        _weaponSystem.CreateBullet();

        // Debug.Log($"x : {_movement.GetDirection().x}, y : {_movement.GetDirection().y}");
    }

    public void SetHeartController(PlayerHeartController heartController)
    {
        _heartController = heartController;
        _heartController.Init(_settings.MaxLife);
    }

    public override void OnFoward(bool isPressed)
    {
        _movement.SetDirectionY(isPressed);
    }

    public override void OnBack(bool isPressed)
    {
        _movement.SetDirectionY(!isPressed);
    }

    public override void OnLeft(bool isPressed)
    {
        _movement.SetDirectionX(!isPressed);
    }

    public override void OnRight(bool isPressed)
    {
        _movement.SetDirectionX(isPressed);
    }

    public override void OnHit()
    {
        base.OnHit();
        _heartController.Decrease();

        // Debug.Log($"Player OnHit. {(int)_status.GetLife().Value}");
        if((int)_status.GetLife().Value <= 0)
        {
            Debug.Log($"{gameObject.tag}'s life is zero!!");
            GameManager.Instance.PlayerDied();
        }
    }

    public void OnBooster(bool enable)
    {
        _booster.Enable(enable);
    }
}
