using UnityEngine.U2D.Animation;

public class EnemyFacade : UnitFacade
{
    private EnemyAnimation _animation;

    void Awake() 
    {
        SpriteResolver spriteResolver = GetComponentInChildren<SpriteResolver>();
        _animation = new EnemyAnimation(spriteResolver, _settings.TimeperFrame);

        _weaponSystem = new WeaponSystem(_bulletSettings, gameObject.transform.position, _settings.ShootingCoolTime);
        _status = new Status(_settings.MaxLife);

        _collisionListener = GetComponent<CollisionListener>();
        _collisionListener.Init(this, gameObject.tag);
    }

    void Update() 
    {
        _animation.OnUpdate();
        _weaponSystem.SetPosition(gameObject.transform.position);
        _weaponSystem.CreateBullet();
    }

    public override void OnHit()
    {
        base.OnHit();
        _animation.SetAnimation("Enemy_Boss_Hit", 1, () => _animation.SetAnimation("Enemy_Boss", 3));
    }
}
