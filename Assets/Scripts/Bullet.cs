using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Serializable] 
    public class Settings
    {
        public Sprite Sprite;
        public Vector2 ColliderSize = Vector3.one;
        public Vector3 Direction = Vector3.zero;
        public float MoveSpeed;
        public string MyTag;
    }

    private Settings _settings;
    private SpriteRenderer _spriteRenderer;
    private const string _tag = "Projectile";

    public void Init(Settings settings)
    {
        _settings = settings;

        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = _settings.Sprite;
        
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        collider.size = _settings.ColliderSize;
        collider.isTrigger = true;

        gameObject.tag = _tag;
    }

    void FixedUpdate()
    {
        gameObject.transform.position += _settings.MoveSpeed * _settings.Direction;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(!col.CompareTag(_settings.MyTag))
        {
            Destroy();
        }
    }

    public string GetMyTag()
    {
        return _settings.MyTag;
    }

    public void Destroy()
    {
        gameObject.SetActive(false);
        BulletObjectPool.Instance.Dispawn(this);
    }
}