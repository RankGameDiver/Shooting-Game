using UnityEngine.U2D.Animation;

public class EnemyFacade : UnitFacade
{
    private EnemyAnimation _animation;

    void Awake() 
    {
        SpriteResolver spriteResolver = GetComponentInChildren<SpriteResolver>();
        _animation = new EnemyAnimation(spriteResolver, _settings.MoveAnimTime);

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
}
