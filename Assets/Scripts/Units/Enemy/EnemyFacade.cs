using UnityEngine;
using UnityEngine.U2D.Animation;

public class EnemyFacade : UnitFacade
{
    private EnemyAnimation _animation;
    private GameObject _objTarget;
    private EnemyMovement _movement;

    void Awake() 
    {
        SpriteResolver spriteResolver = GetComponentInChildren<SpriteResolver>();
        _animation = new EnemyAnimation(spriteResolver, _settings.TimeperFrame);

        _movement = new EnemyMovement(_settings.MoveSpeed, gameObject);
        _weaponSystem = new WeaponSystem(_bulletSettings, gameObject.transform.position, _settings.ShootingCoolTime);
        _status = new Status(_settings.MaxLife);

        _collisionListener = GetComponent<CollisionListener>();
        _collisionListener.Init(this, gameObject.tag);

        _isActive = true;
    }

    void FixedUpdate()
    {
        if(!_isActive)
        {
            return;
        }

        SetDirectionToTarget();
        _movement.OnUpdate();
        _animation.OnUpdate();
        _weaponSystem.SetPosition(gameObject.transform.position);
        _weaponSystem.CreateBullet();
    }

    // 공격 목표 설정
    public void SetTarget(GameObject target)
    {
        _objTarget = target;
    }

    // 공격 목표를 향해 방향 설정
    public void SetDirectionToTarget()
    {
        _movement.SetDirectionToTarget(_objTarget);
    }

    public override void OnHit()
    {
        base.OnHit();
        _animation.SetAnimation("Enemy_Boss_Hit", 1, () => _animation.SetAnimation("Enemy_Boss", 3));
        
        if((int)_status.GetLife().Value <= 0)
        {
            Debug.Log($"{gameObject.tag}'s life is zero!!");
        }
    }
}
