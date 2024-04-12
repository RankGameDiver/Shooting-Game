using System;
using UnityEngine;

public class UnitFacade : MonoBehaviour
{
    [Serializable]
    protected class Settings
    {
        public float TimeperFrame = 0.03f;
        public float MoveSpeed = 0.02f;
        public float ShootingCoolTime = 0.2f;
        public int MaxLife = 3;
    }

    protected Movement _movement;
    protected WeaponSystem _weaponSystem;
    protected Status _status;
    protected CollisionListener _collisionListener;

    [SerializeField] protected Bullet.Settings _bulletSettings;
    [SerializeField] protected Settings _settings;

    public virtual void OnFoward(bool isPressed) { }
    public virtual void OnBack(bool isPressed) { }
    public virtual void OnLeft(bool isPressed) { }
    public virtual void OnRight(bool isPressed) { }

    public virtual void OnHit()
    {
        _status.GetLife().Decrease();
        if((int)_status.GetLife().Value <= 0)
        {
            Debug.Log($"{gameObject.tag}'s life is zero!!");
        }
    }

    public virtual void OnRecovery()
    {
        Debug.Log("OnRecovery");
        _status.GetLife().Increase();
    }

    public virtual void OnDead() { }
}
