using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Serializable] 
    public class Settings
    {
        public Sprite Sprite;
        public Vector3 Direction = Vector3.zero;
        public float MoveSpeed;
    }

    public Settings _settings;

    private SpriteRenderer _spriteRenderer;

    public void Init(Settings settings)
    {
        _settings = settings;

        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = _settings.Sprite;
    }

    void Update()
    {
        gameObject.transform.position += _settings.MoveSpeed * _settings.Direction;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(!col.CompareTag("Player"))
        {
            Destroy();
        }
    }

    public void Destroy()
    {
        gameObject.SetActive(false);
        BulletObjectPool.Instance.Dispawn(this);
    }
}